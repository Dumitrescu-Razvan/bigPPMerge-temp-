import { createBrowserRouter } from 'react-router-dom';
import LoginPage from '../views/LoginPage/LoginPage';
import HomePage from '../views/HomePage/HomePage';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <LoginPage />
  },
  {
    path: '/home',
    element: <HomePage />
  }
]);
