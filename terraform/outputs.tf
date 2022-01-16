output "project_id" {
  value = module.mongodbatlas_project.project_id
}
output "project_name" {
  value = module.mongodbatlas_project.project_name
}
output "standard_srv_connection_string" {
  value = module.mongodbatlas_cluster.standard_srv_connection_string
}
output "database_user_credentials" {
  value     = module.mongodbatlas_database_user.database_user_credentials
  sensitive = true
}

