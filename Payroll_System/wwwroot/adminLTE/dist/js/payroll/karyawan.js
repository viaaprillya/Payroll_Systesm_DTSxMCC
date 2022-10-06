/* <!-- Data Table --> */
$(document).ready(function () {
  $("#tabelKaryawan").DataTable({
    ajax: {
      url: "http://localhost:44392",
      dataSrc: "results",
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
        data: "jabatanID"
      },
    ]
  })
})
