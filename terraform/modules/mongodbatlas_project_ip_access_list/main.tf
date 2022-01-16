resource "mongodbatlas_project_ip_access_list" "cidr_block_entry" {
  project_id = var.project_id
  cidr_block = "0.0.0.0/0"
  comment    = "IP address for tf acc testing"
}
