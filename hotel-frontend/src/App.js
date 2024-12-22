import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Navbar from "./components/Navbar";
import HotelList from "./components/HotelList";
import HotelDetail from "./components/HotelDetail";
import './styles/App.css';

function App() {
    return (
        <Router>
            <Navbar />
            <Routes>
                <Route path="/" element={<HotelList />} />
                <Route path="/hotels/:id" element={<HotelDetail />} />
            </Routes>
        </Router>
    );
}

export default App;
