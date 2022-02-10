import './App.css';
import ChangeColor from './components/ChangeColor';
import Login from './components/Login';
import Profile from './components/Profile';
import AddReceipePage from './pages/AddReceipePage';
import ReceipesListPage from './pages/ReceipesListPage';
import ReceipePage from './pages/RecipePage';


function App() {
  return (
    <div className="App">
      {/* <Profile />
      <Login />
      <ChangeColor /> */}
      <ReceipesListPage />
      <AddReceipePage />
      <ReceipePage />
    </div>
  );
}

export default App;
