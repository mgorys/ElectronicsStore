import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { CategoriesProvider } from './contexts/categories.context';
import { ProductsProvider } from './contexts/products.context';
import { CartProvider } from './contexts/cart.context';
import { UserProvider } from './contexts/user.context';
import { OrdersProvider } from './contexts/orders.context';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <UserProvider>
      <OrdersProvider>
        <CategoriesProvider>
          <ProductsProvider>
            <CartProvider>
              <App />
            </CartProvider>
          </ProductsProvider>
        </CategoriesProvider>
      </OrdersProvider>
    </UserProvider>
  </React.StrictMode>
);
