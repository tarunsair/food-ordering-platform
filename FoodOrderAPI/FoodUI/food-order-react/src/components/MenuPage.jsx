import { useEffect, useState } from "react";
import { getMenuItems, getCategories } from "../api/api";
import MenuList from "./MenuList";
import Header from "./Header";

const MenuPage = () => {
  const [menuItems, setMenuItems] = useState([]);
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    const menuRes = await getMenuItems();
    const catRes = await getCategories();

    setMenuItems(menuRes.data);
    setCategories(catRes.data);
  };

  return (
    <div>
      <Header />

      <div className="container">
        <h1 style={{ textAlign: "center" }}>Explore Our Menu</h1>

        <MenuList menuItems={menuItems} categories={categories} />
      </div>
    </div>
  );
};

export default MenuPage;