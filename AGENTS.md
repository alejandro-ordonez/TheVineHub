# AI Agent Guidelines (Root)

This repository contains the full stack solution for **The Vine Hub**, consisting of a Flutter frontend, a .NET backend, and a SurrealDB database.

## Agent Instructions
When working on this repository, you must adhere to the following guidelines and consult the referenced architecture and agent documents.

### Architecture References
Do not duplicate effort. Read the architecture documents to understand how code should be structured and implemented:
- **General Architecture:** [ARCHITECTURE.md](ARCHITECTURE.md)
- **Backend Architecture:** [backend/ARCHITECTURE.md](backend/ARCHITECTURE.md)
- **Frontend Architecture:** [the_vine_hub_app/ARCHITECTURE.md](the_vine_hub_app/ARCHITECTURE.md)

### Agent Specific Guidelines
More deeply nested `AGENTS.md` files take precedence for their respective directories. You MUST read them when modifying code in those directories:
- **Backend Guidelines:** [backend/AGENTS.md](backend/AGENTS.md)
- **Frontend Guidelines:** [the_vine_hub_app/AGENTS.md](the_vine_hub_app/AGENTS.md)

### General Context & Deployment
- **Deployment:** The CI/CD pipeline builds and runs container images directly on a local self-hosted Raspberry Pi runner, avoiding external container registries like GHCR.
- **Docker:** Deployment uses standard Docker and Docker Compose (discarded previous Podman Quadlet approach).
- **Web:** The Flutter web app is packaged and served using Nginx via multi-stage Docker builds.

### Process Guidelines
- **Deep Planning Mode:** Always enter a deep planning mode before making changes. Ask clarifying questions to eliminate assumptions, create a plan only when absolutely certain, and execute autonomously without further confirmation once the plan is approved.
