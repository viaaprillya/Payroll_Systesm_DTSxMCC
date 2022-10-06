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
      }
    ]
  })
})
