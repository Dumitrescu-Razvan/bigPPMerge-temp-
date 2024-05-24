import React from 'react';
import ReactDOM from 'react-dom/client';
import { GlobalStyle } from './genericStyles/globalStyles.ts';
import { router } from './constants/router.tsx';
import { RouterProvider } from 'react-router-dom';
import { GlobalContext, globalData } from './constants/GlobalContext.tsx';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <GlobalStyle />
    <GlobalContext.Provider value={globalData}>
      <RouterProvider router={router} />
    </GlobalContext.Provider>
  </React.StrictMode>
);
