// App.tsx
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './components/public/home/HomePage';
import AdminHomePage from './components/admin/admin-home-page/AdminHomePage';
import './App.scss';

const App: React.FC = () => {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/admin" element={<AdminHomePage />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;