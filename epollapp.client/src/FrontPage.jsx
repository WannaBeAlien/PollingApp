// FrontPage.jsx
import React, { useState } from 'react';
import axios from 'axios';


const FrontPage = () => {
    const [poll, setPoll] = useState(null);

    const handleAddDefaultPoll = async () => {
        try {
            const response = await axios.get('http://localhost:5080/api/polls/default');
            setPoll(response.data);
        } catch (error) {
            console.error('Error fetching default poll:', error);
        }
    };

    const handleVote = async (pollId, optionId) => {
        try {
            // Send a vote request to the backend VotesController
            await axios.post(`http://localhost:5080/api/votes/${pollId}/vote/${optionId}`);

            // Refresh the poll after voting
            const response = await axios.get('http://localhost:5080/api/polls/default');
            setPoll(response.data);
        } catch (error) {
            console.error('Error voting:', error);
        }
    };


    return (
        <div>
            <h1>ePollApp</h1>
            <button onClick={handleAddDefaultPoll}>Add Default Poll</button>
            {poll && (
                <div>
                    <h2>{poll.title}</h2>
                    <ul>
                        {poll.options.map((option) => (
                            <li key={option.id}>
                                {option.title} - Votes: {option.votes}
                                <button onClick={() => handleVote(poll.id, option.id)}>Vote</button>
                            </li>
                        ))}

                    </ul>
                </div>
            )}
        </div>
    );
};


export default FrontPage;
