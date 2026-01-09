# CurrencyConverterWeb

Live demo: https://currency-converter-demo-jet.vercel.app/

This application allows users to convert amounts between different currencies that are regularly updated.

The main goal of this project was to design and implement a REST API backend, connect it with a frontend application and deploy the whole system to production.

###How it works
1. User submits a currency conversion request and the frontend sends the request to the backend API
2. The backend processes the input data, downloads the latest exchange rate list from an external provider (currently Czech National Bank), parses the data and performs the currency conversion based on the user's input
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
