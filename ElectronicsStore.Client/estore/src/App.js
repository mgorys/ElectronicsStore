import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import NotFound from './NotFound';
import Navigation from './Navigation';
import Home from './Home';
import Shop from './Shop';
import Checkout from './Checkout';
import ProductDetails from './ProductDetails';
import Authorization from './Authorization';

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
