import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getHotelById } from "../api";

const delay = ms => new Promise(res => setTimeout(res, ms));

const HotelDetail = () => {
    const { id } = useParams();
    const [hotel, setHotel] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        const fetchHotel = async () => {
            setIsLoading(true); 
            const data = await getHotelById(id);
            await delay(2000); 
            setHotel(data);
            setIsLoading(false); 
        };
        fetchHotel();
    }, [id]);

    if (isLoading) {
        return <div className="loader"></div>;
    }

    if (!hotel) {
        return <div>No hotel data available.</div>; 
    }

    return (
        <div className="container mt-5">
            <h1>{hotel.name}</h1>
            <p>Location: {hotel.location}</p>
            <p>Rating: {hotel.rating}</p>
            <p>Board Basis: {hotel.boardBasis}</p>
            <h2>Rooms</h2>
            <ul>
                {hotel.rooms.map((room, index) => (
                    <li key={index}>
                        {room.roomType}: {room.amount}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default HotelDetail;
