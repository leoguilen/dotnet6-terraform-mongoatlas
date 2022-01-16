output "database_user_credentials" {
  value     = [for props in mongodbatlas_database_user.database_user : { username = props.username, password = props.password }]
  sensitive = true
}

