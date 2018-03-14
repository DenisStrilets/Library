$(document).ready(function () {
    dataSource = new kendo.data.DataSource({


        transport: {
            read:
            {
                url: "library/getall",
                dataType: "json",
            },
        },

        schema:
        {
            model:
            {

                fields: {
                    Price: { editable: false, nullable: true, type: "number" },
                    Name: { editable: true, nullable: true, type: "string" },
                    Type: { editable: true, nullable: true, type: "string" },
                }
            }
        }

    });

    $("#library-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: "inline",

        columns: [
            {
                field: "Name",
                title: "Name",
                sortable: true
            },
            {
                field: "Price",
                title: "Price",
                sortable: true
            },
            {
                field: "Type",
                title: "Type",
                sortable: false
            },

            {

                title: "Image",
                template: '<img style="width: 80px; height: 60px;" src="data:image/gif;base64,#=Image64#" />'
            },

        ],
        height: "500px",
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
    }).data("kendoGrid");
});