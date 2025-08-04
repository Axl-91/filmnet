# FilmNet Project Makefile

# Default target
.DEFAULT_GOAL := help

# Variables
PROJECT_DIR := FilmNet
COMPOSE_FILE := $(PROJECT_DIR)/docker-compose.yml

# Colors for output
RED := \033[31m
GREEN := \033[32m
YELLOW := \033[33m
BLUE := \033[34m
RESET := \033[0m

.PHONY: help up dev run watch-run down build test

help: ## Show this help message
	@echo -e "$(BLUE) FilmNet Project Commands: $(RESET)"
	@echo ""
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | sort | awk 'BEGIN {FS = ":.*?## "}; {printf "$(GREEN)%-12s$(RESET) %s\n", $$1, $$2}'

up: ## Start containers
	@echo -e "$(YELLOW)Starting containers...$(RESET)"
	cd $(PROJECT_DIR) && docker compose up -d
	@echo -e "$(GREEN)Containers started!$(RESET)"

dev: watch-run ## Alias for 'watch-run' command

watch-run: up ## Start container and run app with hot reload (development mode)
	@echo -e "$(YELLOW)Starting .NET application with hot reload...$(RESET)"
	cd $(PROJECT_DIR) && dotnet watch run

run: up ## Start container and run app
	@echo -e "$(YELLOW)Starting .NET application...$(RESET)"
	cd $(PROJECT_DIR) && dotnet run

down: ## Stop and remove containers
	@echo -e "$(YELLOW)Stopping and removing containers...$(RESET)"
	cd $(PROJECT_DIR) && docker compose down
	@echo -e "$(GREEN)Containers stopped and removed!$(RESET)"

build: ## Build the .NET project
	@echo -e "$(YELLOW)Building .NET project...$(RESET)"
	cd $(PROJECT_DIR) && dotnet build
	@echo -e "$(GREEN)Build completed!$(RESET)"

test: ## Run tests
	@echo "$(YELLOW)Running tests...$(RESET)"
	cd $(PROJECT_DIR) && dotnet test
	@echo "$(GREEN)Tests completed!$(RESET)"