variable "project_id" {
  description = "The MongoDB Atlas Project Id"
}
variable "cluster_name" {
  type        = string
  description = "The MongoDB Atlas Cluster Name"
}
variable "database_user_infos" {
  type = map(object({
    username = string
    roles = map(object({
      role_name     = string
      database_name = string
    }))
  }))
  description = "The MongoDB Atlas Database User Roles"
}
