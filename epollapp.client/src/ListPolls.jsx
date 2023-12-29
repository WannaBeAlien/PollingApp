// ListPolls.js
import React, { useEffect, useState } from 'react';
import ApiService from './ApiService'; // You need to create an ApiService component for making API calls

const ListPolls = () => {
    const [polls, setPolls] = useState([]);

    useEffect(() => {
        // Fetch the list of polls when the component mounts
        fetchPolls();
    }, []);

    const fetchPolls = async () => {
        try {
            const response = await ApiService.get('/api/polls');
            setPolls(response.data);
        } catch (error) {
            console.error('Error fetching polls:', error);
        }
    };

    return (
        <div>
            <h2>List of Polls</h2>
            <ul>
                {polls.map((poll) => (
                    <li key={poll.id}>
                        <a href={`/polls/${poll.id}`}>{poll.title}</a>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ListPolls;
