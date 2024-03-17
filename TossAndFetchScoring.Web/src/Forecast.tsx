import React, { useState, useEffect } from 'react';

interface Forecast {
  date: string;
  temperatureC: number;
  summary: string;
  temperatureF: number;
}

const WeatherForecast: React.FC = () => {
  const [forecasts, setForecasts] = useState<Forecast[]>([]);
  const backendurl = import.meta.env.VITE_services__apiservice__0

  useEffect(() => {
    const fetchForecast = async () => {
      try {
        const response = await fetch(backendurl + '/weatherforecast');
        const data = await response.json();
        setForecasts(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchForecast();
  }, []);

  return (
    <div>
      <h2>Weather Forecast</h2>
      <table>
        <thead>
          <tr>
            <th>Date</th>
            <th>Temperature (°C)</th>
            <th>Temperature (°F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map((forecast) => (
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default WeatherForecast;
