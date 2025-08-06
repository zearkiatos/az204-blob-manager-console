build:
	dotnet build az204-blob-manager-console.sln

run:
	dotnet run

docker-up:
	docker compose up --build

docker-down:
	docker compose down

podman-up:
	podman compose up --build

podman-down:
	podman compose down