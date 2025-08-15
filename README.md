# MVP Studio - Project Mars

### 1. Install Docker
Ensure you have the latest version of Docker installed. You can download it from Docker's official website. Follow the instructions for your operating system.

### 2. Running Docker
1. Get the project files using one of these methods:
   - Clone this repository: `git clone [repository-url]`
   - Download as ZIP file from the repository and extract it
2. Open CMD, PowerShell, or Terminal
3. Navigate to the project directory: `cd [project-directory-path]`
4. Start the server and services: `docker compose up`
5. To stop and remove running containers: `docker compose down`

### 3. Important Notes
* **Windows Users**: Ensure Docker is set to run in Linux Containers mode before executing the commands (Right click bottom right Docker Icon and you should be able to see the option to switch).
* **Project URL**: http://localhost:5003
* Make sure Docker is updated to the latest version to avoid compatibility issues.

### Resources
* More Tutorial: https://www.youtube.com/watch?v=HG6yIjZapSA

---

## MongoDB Setup for Mars Project

### For new users:
1. Just run:
   ```
   docker-compose up
   ```

### Existing user who download Mars before and have missing data issue(eg, category):
1. Stop all existing docker services if any:
   ```
   docker-compose down
   ```

2. Run the service again:
   ```
   docker-compose up -d mongodb
   ```

3. Run the following script to populate data:
   ```
   docker-compose run mongodb-seeder
   ```