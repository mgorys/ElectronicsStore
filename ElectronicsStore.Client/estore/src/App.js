import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import NotFound from './NotFound';
import Navigation from './NavBar/Navigation';
import Home from './HomePage/Home';
import Shop from './ShopPage/Shop';
import Checkout from './CheckoutPage/Checkout';
import ProductDetails from './ProductDetails/ProductDetails';
import Authorization from './AuthPage/Authorization';

function App() {
  return (
    <>
      <Router>
        <Navigation />
        <Routes>
          <Route exact path="/" element={<Home />}></Route>
          <Route path="shop/*" element={<Shop />} />
          <Route path="checkout" element={<Checkout />} />
          <Route path="product/:name" element={<ProductDetails />} />
          <Route path="auth" element={<Authorization />} />
          <Route path="*" element={<NotFound />}></Route>
        </Routes>
      </Router>
    </>
  );
}

export default App;
