import './App.css';
import Header from './Header';
import Body from './Body';
import { Routes, Route, Router } from 'react-router'

function App() {
  return (
    <div className="App">
      <Header />
      {/* <Router>
        <Routes>
          <Route path='/' element={<Body />} />
        </Routes>
      </Router> */}
    </div>
  );
}

export default App;
