resource "random_string" "password" {
  length  = 16
  special = true
}

resource "mongodbatlas_database_user" "database_user" {
  for_each = var.database_user_infos

  username           = each.value.username
  password           = sha256(bcrypt(random_string.password.result))
  project_id         = var.project_id
  auth_database_name = "admin"

  dynamic "roles" {
    for_each = each.value.roles
    content {
      role_name     = roles.value.role_name
      database_name = roles.value.database_name
    }
  }

  scopes {
    name = var.cluster_name
    type = "CLUSTER"
  }

  lifecycle {
    ignore_changes = [password]
  }
}
