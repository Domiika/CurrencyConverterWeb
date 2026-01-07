import {useEffect, useState} from "react";
import Select from "react-select";
import "./App.css";
import apis from "./api/api";

function App() {
  const [fromCurrency, setFromCurrency] = useState(null);
  const [toCurrency, setToCurrency] = useState(null);
  const [currencies, setCurrencies] = useState([]);
  const [validityDate, setValidityDate] = useState("failed to load");
  const [amount, setAmount] = useState("");
  const [result, setResult] = useState(null);

  useEffect(() => {
    apis.loadSupportedCurrencies()
      .then(res => {
        console.log("DATA FROM API:", res.data);
        setCurrencies(res.data.supportedCurrencies);
        setValidityDate(res.data.validityDate);
      })
      .catch(err => {
        console.error("API ERROR:", err);
        setValidityDate("failed to load");
      });
  }, []);

  const currencyOptions = currencies.map(c => ({
    value: c,
    label: c
  }));

  const handleSubmit = async (e) => {
  e.preventDefault();
    try {
      const res = await apis.convert(
        fromCurrency.value,
        toCurrency.value,
        amount
      );

      setResult(res.data.result);
    } catch (err) {
      console.error(err);
    }
  };
  
  console.log("CURRENCIES:",currencies);

  return (
    <div className="container">
      <h1>Currency Converter</h1>
      <form>
        <label htmlFor="amount">Amount</label>
        <br></br>
        <input
          id="amount"
          placeholder="Type amount"
          className="text-input"
          name="amount"
          type="number"
          value={amount}
          onChange={(e) => setAmount(e.target.value)}
        />
        <br></br>
        <br></br>
        <label htmlFor="fromCurrency">From</label>
        <Select
          inputId="fromCurrency"
          options={currencyOptions}
          value={fromCurrency}
          onChange={setFromCurrency}
          placeholder="Select currency..."
          isSearchable
        />
        <br></br>
        <label htmlFor="toCurrency">Convert to</label>
        <Select
          inputId="toCurrency"
          options={currencyOptions}
          value={toCurrency}
          onChange={setToCurrency}
          placeholder="Select currency..."
          isSearchable
        />
        <br></br>
        <br></br>
        <label>Currency rates last update: {validityDate}</label>
        <br></br>
        <br></br>
        <button onClick={handleSubmit}>Submit</button>
        <br></br>
        <br></br>
        <label>Result: {result !== null ? `${result} ${toCurrency?.value}` : ""}</label>
      </form>
      <br></br>
      <hr></hr>
      <label>By Dominik Sojak</label>
    </div>
  );
}

export default App;
