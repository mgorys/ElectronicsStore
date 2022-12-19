import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import NotFound from './NotFound';
import Navigation from './Navigation';
import Home from './Home';
import Shop from './Shop';
import Checkout from './Checkout';
import ProductDetails from './ProductDetails';

function App() {
  return (
    <>
      <Router>
        <Navigation />
        <Routes>
          <Route exact path="/" element={<Home />}></Route>
          <Route path="shop/*" element={<Shop />} />
          <Route path="checkout" element={<Checkout />} />
          <Route path="product" element={<ProductDetails />} />
          <Route path="*" element={<NotFound />}></Route>
        </Routes>
      </Router>
    </>
  );
}

export default App;

// <Router>
//   <div className="App">
//     <Navbar />
//     <div className="content">
//       <Routes>
//         <Route exact path="/" element={<HomeContainer />} />
//         <Route exact path="/create" element={<Create />} />
//         <Route exact path="/books/:name" element={<BookDetails />} />
//         <Route path="*" element={<NotFound />} />
//       </Routes>
//     </div>
//   </div>
// </Router>;
