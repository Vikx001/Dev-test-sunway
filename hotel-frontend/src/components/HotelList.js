import React, { useEffect, useState } from "react";
import { getHotels } from "../api";
import { Link } from "react-router-dom";

const delay = ms => new Promise(res => setTimeout(res, ms));

const HotelList = () => {
    const [hotels, setHotels] = useState([]);
    const [searchTerm, setSearchTerm] = useState("");
    const [filteredHotels, setFilteredHotels] = useState([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        const fetchHotels = async () => {
            setLoading(true); 
            const data = await getHotels();
            await delay(2000); 
            setHotels(data);
            setFilteredHotels(data);
            setLoading(false); 
        };
        fetchHotels();
    }, []);

    useEffect(() => {
        const results = hotels.filter(hotel =>
            hotel.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
            hotel.location.toLowerCase().includes(searchTerm.toLowerCase())
        );
        setFilteredHotels(results);
    }, [searchTerm, hotels]);

    if (loading) {
        return <div className="loader"></div>; 
    }

    return (
        <div className="container mt-5">
            <div className="d-flex justify-content-between align-items-center mb-4">
                <h1 className="mb-0">Explore Hotels</h1>
                <input
                    type="text"
                    className="form-control search-input"
                    placeholder="Search by hotel name or location..."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
            </div>
            <div className="row">
                {filteredHotels.map((hotel) => (
                    <div className="col-md-4 mb-3" key={hotel.id}>
                        <div className="card">
                            <img
                                src={hotel.imageUrl}
                                className="card-img-top"
                                alt={hotel.name}
                            />
                            <div className="card-body">
                                <h5 className="card-title">{hotel.name}</h5>
                                <p className="card-text">{hotel.location}</p>
                                <Link to={`/hotels/${hotel.id}`} className="btn btn-primary">
                                    View Details
                                </Link>
                            </div>
                        </div>
                    </div>
                ))}
                {filteredHotels.length === 0 && (
                    <p className="text-center mt-4">No hotels match your search.</p>
                )}
            </div>
        </div>
    );
};

export default HotelList;
