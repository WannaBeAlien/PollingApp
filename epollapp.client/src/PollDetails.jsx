// PollDetails.js
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import ApiService from './ApiService'; // You need to create an ApiService component for making API calls

const PollDetails = () => {
    const { id } = useParams();
    const [poll, setPoll] = useState(null);

    useEffect(() => {
        // Fetch the details of the specific poll when the component mounts
        fetchPollDetails();
    }, [id]);

    const fetchPollDetails = async () => {
        try {
            const response = await ApiService.get(`/api/polls/${id}`);
            setPoll(response.data);
        } catch (error) {
            console.error(`Error fetching poll details for poll ID ${id}:`, error);
        }
    };

    if (!poll) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h2>{poll.title}</h2>
            <ul>
                {poll.options.map((option) => (
                    <li key={option.id}>
                        {option.title} - Votes: {option.votes}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default PollDetails;
