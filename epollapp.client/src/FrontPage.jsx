
import React, { useState } from 'react';
import axios from 'axios'; // Import axios for making HTTP requests

import './FrontPage.css';

const FrontPage = () => {
    const [gettingDefaultPoll, setGettingDefaultPoll] = useState(false);

    const handleGetDefaultPoll = async () => {
        try {
            setGettingDefaultPoll(true);

            // Make a GET request to your C# backend to get the default poll
            const response = await axios.get('/api/Polls/default');

            const defaultPoll = response.data;

            console.log(defaultPoll); // Log the default poll

            // You can add additional logic or set the state based on the default poll

        } catch (error) {
            console.error('Error getting default poll:', error);
        } finally {
            setGettingDefaultPoll(false);
        }
    };


    return (
        <div className="front-page">
            <h1>ePollApp</h1>
            <button>Add your own poll</button>
            <button onClick={handleGetDefaultPoll} disabled={gettingDefaultPoll}>{gettingDefaultPoll ? 'Getting Default Poll...' : 'Get Default Poll'}
            </button>
        </div>
    );
};

export default FrontPage;
