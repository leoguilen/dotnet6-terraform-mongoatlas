variable "project_id" {
  description = "The MongoDB Atlas Project Id Created"
}
variable "cluster_name" {
  type        = string
  description = "The MongoDB Atlas Cluster Name"
}
variable "cluster_provider_name" {
  type        = string
  description = "The MongoDB Atlas Cluster Provider Name"
}
variable "cluster_provider_region_name" {
  type        = string
  description = "The MongoDB Atlas Cluster Provider Region Name"
}
variable "cluster_provider_instance_size_name" {
  type        = string
  description = "The MongoDB Atlas Cluster Provider Instance Size Name"
  default     = "M0"
}
