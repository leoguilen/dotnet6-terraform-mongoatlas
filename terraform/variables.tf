# variable "public_key" {
#   description = "Public API key to authenticate to Atlas"
# }
# variable "private_key" {
#   description = "Private API key to authenticate to Atlas"
# }
variable "org_id" {
  description = "MongoDB Organization ID"
}
variable "database_name" {
  description = "MongoDB Database Name"
  default     = "CAR_RENT_STORE"
}
