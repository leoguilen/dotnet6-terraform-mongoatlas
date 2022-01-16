resource "mongodbatlas_search_index" "index" {
  project_id = var.project_id
  cluster_name = var.cluster_name
  collection_name = var.collection_name
  database = var.database_name
  name = "cars_catalog_search_index"
  analyzer = "lucene.standard"
  search_analyzer = "lucene.standard"
  mappings_dynamic = false
  mappings_fields = <<-EOF
{
    "CAR_ADDITIONAL_DETAILS": {
        "type": "string"
    },
    "CAR_COLOR_NAME": {
        "type": "string"
    },
    "CAR_MAKE_NAME": {
        "type": "string"
    },
    "CAR_MODEL_NAME": [
        {
            "type": "string"
        },
        {
            "type": "autocomplete"
        }
    ],
    "CAR_YEAR_NUMBER": {
        "indexDoubles": false,
        "representation": "int64",
        "type": "number"
    },
    "MANUFACTURER_NAME": {
        "type": "string"
    }
}
EOF
}