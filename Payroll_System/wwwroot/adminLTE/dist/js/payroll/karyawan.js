/* <!-- Data Table --> */
$(document).ready(function () {
  $("#tabelPokemon").DataTable({
    ajax: {
      url: "https://pokeapi.co/api/v2/pokemon/",
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
        data: "name",
        render: function (data, type, row) {
          return sentenceCase(data);
        }
      },
      {
        data: "",
        render: function (data, type, row) {
          return `<button class="btn btn-primary" onclick="detailPokemon('${row.url}')" data-bs-toggle="modal" data-bs-target="#modalDetailPokemon">Detail</button>`
        }
      },
    ]
  })
})
