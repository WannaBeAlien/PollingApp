
import axios from 'axios';

const ApiService = axios.create({
    baseURL: 'http://localhost:5173', // Adjust the URL to match your backend server URL
    headers: {
        'Content-Type': 'application/json',
    },
});

export default ApiService;
