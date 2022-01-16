# Mongo Projects
# ---------------------
module "mongodbatlas_project" {
  source = "./modules/mongodbatlas_project"

  project_name = "Hackathon"
  org_id       = var.org_id
}
module "mongodbatlas_project_ip_access_list" {
  source = "./modules/mongodbatlas_project_ip_access_list"

  project_id = module.mongodbatlas_project.project_id

  depends_on = [module.mongodbatlas_cluster]
}

# Mongo Clusters
# ---------------------
module "mongodbatlas_cluster" {
  source = "./modules/mongodbatlas_cluster"

  project_id                   = module.mongodbatlas_project.project_id
  cluster_name                 = "Cluster-Hackathon"
  cluster_provider_name        = "AWS"
  cluster_provider_region_name = "US_EAST_1"

  depends_on = [module.mongodbatlas_project]
}

# Mongo Database
# ---------------------
module "mongodbatlas_database_user" {
  source = "./modules/mongodbatlas_database_user"

  project_id   = module.mongodbatlas_project.project_id
  cluster_name = "Cluster-Hackathon"

  database_user_infos = {
    adminUser = {
      username = "admin",
      roles = {
        role1 = {
          role_name     = "dbAdmin",
          database_name = var.database_name
        },
        role2 = {
          role_name     = "readWrite",
          database_name = var.database_name
        },
        role3 = {
          role_name     = "dbAdmin",
          database_name = "admin"
        },
        role4 = {
          role_name     = "readWrite",
          database_name = "admin"
        }
      }
    },
    queryUser = {
      username = "query-api-user",
      roles = {
        role1 = {
          role_name     = "read"
          database_name = var.database_name
        }
      }
    },
    commandUser = {
      username = "command-api-user",
      roles = {
        role1 = {
          role_name     = "readWrite"
          database_name = var.database_name
        }
      }
    }
  }

  depends_on = [module.mongodbatlas_cluster]
}

# Mongo Database Search Index
# ---------------------
# module "mongodbatlas_search_index" {
#   source = "./modules/mongodbatlas_search_index"

#   project_id      = module.mongodbatlas_project.project_id
#   cluster_name    = "Cluster-Hackathon"
#   database_name   = "CAR_RENT_STORE"
#   collection_name = "CARS_CATALOG"

#   depends_on = [module.mongodbatlas_cluster]
# }
