import * as React from 'react';
import * as ReactDOM from 'react-dom/client';
import * as createRoot from 'react-dom/client';
import App from './App';
import './index.scss'

// Get the root element from the DOM
const rootElement: HTMLElement | null = document.getElementById('root');

// Check if the root element exists before rendering the app
if (rootElement) {
  const root = ReactDOM.createRoot(rootElement);

  root.render(
    <React.StrictMode>
      <App />
    </React.StrictMode>,
  );
} else {
  console.error("Root element 'root' not found in the document.");
}