/* <!-- Data Table --> */
$(document).ready(function () {
  $("#tabelKaryawan").DataTable({
    ajax: {
      url: "https://localhost:44392/api/Karyawan",
      type: "GET",
      dataSrc: "data",
      dataType: "JSON"
    },
    columns: [
      {
        "data": null,
        "render": function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1;
        }
      },
      {
        data: "namaLengkap"
      },
      {
        data: "email"
      },
      {
        data: "nomerRekening"
      },
      {
        data: "nomerTelepon"
      },
      {
        data: "jabatan.nama"
      },
      {
        data: "",
        render: function (data, type, row) {
          return `<button class="btn btn-warning" id="buttonUpdateKaryawan" data-id="${row.id}" data-bs-toggle="modal" data-bs-target="#modalUpdateKaryawan">Edit</button>
                  <button class="btn btn-danger" id="buttonDeleteKaryawan" data-id="${row.id}" data-bs-toggle="modal" data-bs-target="#modalDeleteKaryawan">Delete</button>`
        }
      }
    ]
  })
})

$(document).on("click", "#buttonInputKaryawan", function () {
  $.ajax({
    url: "https://localhost:44392/api/Jabatan",
    type: "GET"
  }).done((result) => {
    test = "<option selected>Jabatan</option>"
    $.each(result.data, function (key, val) {
      console.log("jabatan =" + val.nama)
        test += `<option value="${val.id}">${val.nama}</option>`;
        console.log(test)
    })
    $("#selectJabatan").html(test)
  }).fail((error) => {
    console.log(error);
  })
})

$(document).on("click", "#buttonUpdateKaryawan", function () {
  var id = parseInt($(this).data('id'));
  $("#submitUpdate").data('id', id);

  $.ajax({
    url: "https://localhost:44392/api/Jabatan",
    type: "GET"
  }).done((result) => {
    test = "<option selected>Jabatan</option>"
    $.each(result.data, function (key, val) {
      console.log("jabatan =" + val.nama)
      test += `<option value="${val.id}">${val.nama}</option>`;
      console.log(test)
    })
    $("#selectEditJabatan").html(test)
  }).fail((error) => {
    console.log(error);
  })

  $.ajax({
    url: "https://localhost:44392/api/Karyawan/id?id="+id,
    type: "GET"
  }).done((result) => {
    $("#editNama").val(result.data.namaLengkap)
    $("#editEmail").val(result.data.email)
    $("#editRekening").val(result.data.nomerRekening)
    $("#editTelepon").val(result.data.nomerTelepon)
    $(`#selectEditJabatan option[value=${result.data.jabatanID}]`).attr('selected','selected')
  }).fail((error) => {
    console.log(error);
  })
})

$(document).on("click", "#buttonDeleteKaryawan", function() {
  var id = parseInt($(this).data('id'));
  $("#buttonDeleteConfirmed").data('id', id);

  $.ajax({
    url: "https://localhost:44392/api/Karyawan/id?id="+id,
      type: "GET"
  }).done((result) => {
    var nama = result.data.namaLengkap
    console.log("nama =" + nama)
    var confirmed = "Apakah kamu yakin ingin menghapus data " + nama + " ?";
    $("#deleteConfirmed").html(confirmed);
  }).fail((error) => {
    console.log(error);
  })
})

function InputKaryawan() {
  console.log("Masuk Input Karyawan")
  console.log("Selected Jabatan"+$("#selectJabatan option:selected").val())
  var karyawan = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
  //ini ngambil value dari tiap inputan di form nya
  karyawan.namaLengkap = $("#inputNama").val();
  karyawan.email = $("#inputEmail").val();
  karyawan.nomerRekening = $("#inputRekening").val();
  karyawan.nomerTelepon = $("#inputTelepon").val();
  karyawan.jabatanID = parseInt($("#selectJabatan option:selected").val());
  console.log(karyawan)
  //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
  $.ajax({
    url: "https://localhost:44392/api/Karyawan",
    type: "POST",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    data: JSON.stringify(karyawan) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
  }).done((result) => {
    swal("Good job!", "Karyawan berhasil ditambahkan!", "success").then(function () {
      location.reload()
    })
  }).fail((error) => {
    swal("Sorry!", "Karyawan gagal ditambahkan!", "error");
  })
}

function UpdateKaryawan() {
  var id = $("#submitUpdate").data('id');
  console.log("Masuk Fungsi Update ID = " + id)
  var karyawan = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
  //ini ngambil value dari tiap inputan di form nya
  karyawan.id = parseInt(id);
  karyawan.namaLengkap = $("#editNama").val();
  karyawan.email = $("#editEmail").val();
  karyawan.nomerRekening = $("#editRekening").val();
  karyawan.nomerTelepon = $("#editTelepon").val();
  karyawan.jabatanID = parseInt($("#selectEditJabatan option:selected").val());
  console.log(karyawan)
  //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
  $.ajax({
    url: "https://localhost:44392/api/Karyawan",
    type: "PUT",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    data: JSON.stringify(karyawan) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
  }).done((result) => {
    swal("Good job!", "Karyawan berhasil diubah!", "success").then(function () {
      location.reload()
    })
  }).fail((error) => {
    swal("Sorry!", "Karyawan gagal diubah!", "error");
  })
}

function DeleteKaryawan() {
  var id = parseInt($("#buttonDeleteConfirmed").data('id'));
  $.ajax({
    url: "https://localhost:44392/api/Karyawan",
    type: "DELETE",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    data: id //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
  }).done((result) => {
    swal("Good job!", "Karyawan berhasil dihapus!", "success").then(function () {
      location.reload()
    })
  }).fail((error) => {
    swal("Sorry!", "Karyawan gagal dihapus!", "error");
  })
}
