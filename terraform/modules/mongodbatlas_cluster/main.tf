resource "mongodbatlas_cluster" "cluster" {
  project_id = var.project_id
  name       = var.cluster_name

  # Provider Settings "block"
  provider_name               = "TENANT"
  backing_provider_name       = var.cluster_provider_name
  provider_region_name        = var.cluster_provider_region_name
  provider_instance_size_name = var.cluster_provider_instance_size_name

  labels {
    key   = "Environment"
    value = "DEV"
  }
}
