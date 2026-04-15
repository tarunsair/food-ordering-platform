import axios from "axios";

const API_BASE_URL = "http://localhost:5180/api/FoodMenu"; 
// change port if needed

export const getCategories = () => axios.get(`${API_BASE_URL}/categories`);
export const getMenuItems = () => axios.get(`${API_BASE_URL}/menuitems`);

// ✅ NEW: Create Order API
export const createOrder = (orderData) =>
  axios.post(`${API_BASE_URL}/orders`, orderData);