output "standard_srv_connection_string" {
  value = mongodbatlas_cluster.cluster.connection_strings[0].standard_srv
}
# Example return string: standard_srv = "mongodb+srv://cluster-atlas.ygo1m.mongodb.net"
