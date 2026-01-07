import axios from "axios";

const baseURL = import.meta.env.VITE_CURRENCY_API_URL;
const api = axios.create({
    baseURL
});

export const loadSupportedCurrencies = () => api.get("/currency/info");
export const convert = (from, to, amount) => 
    api.get("currency/convert", {
        params: {
            from,
            to,
            amount,
        }
    });

const apis = {
    loadSupportedCurrencies,
    convert,
}

export default apis;