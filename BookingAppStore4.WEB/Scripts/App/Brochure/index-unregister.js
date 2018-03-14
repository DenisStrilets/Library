$(document).ready(function () {
    dataSource = new kendo.data.DataSource({


        transport: {
            read:
            {
                url: "brochure/getall",
                dataType: "json",
            },

        },

        schema:
        {
            model:
            {
                id: "BrochureId",
                fields: {
                    BrochureId: { editable: false, nullable: true, type: "number" },
                    Name: { editable: true, nullable: true, type: "string" },
                    RedactionName: { editable: true, nullable: true, type: "string" },
                    Theme: { editable: true, nullable: true, type: "string" },

                    Price: { editable: false, nullable: true, type: "number" },
                    MinOrdering: { editable: false, nullable: true, type: "number" },
                }
            }
        }


    });

    $("#brochures-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: "inline",

        columns: [
            {
                field: "Name",
                title: "Brochure",
                sortable: true
            },

            {
                field: "Price",
                title: "Price",
                sortable: true
            },

            {
                title: "Image",
                template: '<img style="width: 80px; height: 60px;" src="data:image/gif;base64,#=Image64#" />'
            }

        ],
        height: "500px",
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
    }).data("kendoGrid");
});