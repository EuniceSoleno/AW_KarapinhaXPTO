import axios from 'axios';

const API_URL = 'https://localhost:7224/api/Categoria';

const getCategories = () => {
  return axios.get(API_URL);
};

const getCategoryById = (id) => {
  return axios.get(`${API_URL}/${id}`);
};

const createCategory = (category) => {
  return axios.post(API_URL, category);
};

const updateCategory = (id, category) => {
  return axios.put(`${API_URL}/${id}`, category);
};

const deleteCategory = (id) => {
  return axios.delete(`${API_URL}/${id}`);
};

export { getCategories, getCategoryById, createCategory, updateCategory, deleteCategory };
