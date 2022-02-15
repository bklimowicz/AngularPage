import './App.css';
import AddReceipePage from './pages/AddReceipePage';
import ReceipesListPage from './pages/ReceipesListPage';
import ReceipePage from './pages/RecipePage';


function App() {
  return (
    <div className="App">
      <ReceipesListPage />
      <AddReceipePage />
      <ReceipePage />
    </div>
  );
}

export default App;
