#----------------------
# Makefile Commands
#----------------------

all: add-additional-packages build-env setup-env

add-additional-packages: install-mongosh

build-env: init-and-validate-tf-files run-tf-plan apply-tf-resources

setup-env: create-database-collections-indexes-seed-initial-data

#----------------------------
# Install Aditional Packages
#----------------------------

install-mongosh:
	@echo "1° step: Installing mongosh..."
	@sudo apt-get install gnupg
	@wget -qO - https://www.mongodb.org/static/pgp/server-5.0.asc | sudo apt-key add -
	@echo "deb [ arch=amd64,arm64 ] https://repo.mongodb.org/apt/ubuntu focal/mongodb-org/5.0 multiverse" | sudo tee /etc/apt/sources.list.d/mongodb-org-5.0.list
	@sudo apt-get update
	@sudo apt-get install -y mongodb-mongosh
	@mongosh -h
	@echo "...Done 🏁"

install-jq:
	@echo "2° step: Installing jq..."
	@sudo apt-get install -y jq
	@echo "...Done 🏁"

#-------------------------
# Mongo Environment Setup
#-------------------------

## Create Mongo Infrastructure

init-and-validate-tf-files:
	@echo "3° step: Initializing terraform modules..."
	@terraform -chdir="./terraform/" init
	@echo "...Done 🏁"
	@echo "4° step: Validating terraform files..."
	@terraform -chdir="./terraform/" fmt && terraform -chdir="./terraform/" validate
	@echo "...Done 🏁"

run-tf-plan:
	@echo "5° step: Running terraform plan..."
	@terraform -chdir="./terraform/" plan \
		-var "org_id=${MONGODB_ATLAS_ORGANIZATION_ID}"
	@echo "...Done 🏁"

apply-tf-resources:
	@echo "6° step: Applying terraform resources..."
	@terraform -chdir="./terraform/" apply -auto-approve \
		-var "org_id=${MONGODB_ATLAS_ORGANIZATION_ID}"
	@cd ../../
	@echo "...Done 🏁"

## Configure Mongo Database/Collection

create-database-collections-indexes-seed-initial-data:
	@echo "7° step: Creating database and collections..."
	@sleep 15
	@mongosh `terraform -chdir="./terraform/" output -raw standard_srv_connection_string` \
		-u `terraform -chdir="./terraform/" output -json database_user_credentials | jq '.[0].username'` \
		-p `terraform -chdir="./terraform/" output -json database_user_credentials | jq '.[0].password'` \
		--authenticationDatabase admin -f initMongo.js
	@echo "...Done 🏁"