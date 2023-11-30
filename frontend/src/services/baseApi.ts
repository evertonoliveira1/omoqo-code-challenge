import axios, { AxiosError } from 'axios';

export const api = axios.create({
  baseURL:
  process.env.BASE_API_URL || 'http://localhost:8080/api/',
});

api.interceptors.response.use(undefined, (error: AxiosError) => {
});

export const getRequest = async (path: string, params?: any) => {
  const { data } = await api.get(path, { params });
  return data;
};

export const postRequest = async (path: string, body: any) => {
  const { data } = await api.post(path, body);
  return data;
};

export const putRequest = async (path: string, body: any) => {
  const { data } = await api.put(path, body);
  return data;
};

export const deleteRequest = async (path: string) => {
  const { data } = await api.delete(path);
  return data;
};