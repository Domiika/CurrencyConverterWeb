# CurrencyConverterWeb

Live demo: https://currency-converter-demo-jet.vercel.app/

This application allows users to convert amounts between different currencies that are regularly updated.

The main goal of this project was to design and implement a REST API backend, connect it with a frontend application and deploy the whole system to production.

### How it works
1. User submits a currency conversion request and the frontend sends the request to the backend API
2. The backend processes the input data, downloads the latest exchange rate list from an external provider (currently Czech National Bank), parses the data and returns the currency conversion based on the user's input
3. The converted result is then returned to the frontend and displayed to the user

## Tech-stack
### Backend
- C#
- ASP.NET Core / .NET
- CsvHelper
- HttpClient

### Frontend
- React + Vite
- JavaScript
- HTML + CSS
- Axios

### Deployment
- Docker

## Installation & Run
If you just want to test it out, you can try this Live demo mentioned earlier: https://currency-converter-demo-jet.vercel.app/

Or you can run the application locally with Docker. (Docker needs to be installed)

Clone the repository to your folder and then compose up the project
```bash
git clone https://github.com/Domiika/CurrencyConverterWeb.git
cd CurrencyConverterWeb
docker compose up
```
