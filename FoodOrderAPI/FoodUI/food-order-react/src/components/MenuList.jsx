import { useState } from "react";
import MenuItemCard from "./MenuItemCard";

const MenuList = ({ menuItems, categories }) => {
  const [selectedCategory, setSelectedCategory] = useState(0);

  const filteredItems =
    selectedCategory === 0
      ? menuItems
      : menuItems.filter((x) => x.categoryId === selectedCategory);

  return (
    <div>
      {/* CATEGORY FILTER */}
      <div style={styles.tabs}>
        <button
          style={selectedCategory === 0 ? styles.active : styles.tab}
          onClick={() => setSelectedCategory(0)}
        >
          All
        </button>

        {categories.map((cat) => (
          <button
            key={cat.id}
            style={selectedCategory === cat.id ? styles.active : styles.tab}
            onClick={() => setSelectedCategory(cat.id)}
          >
            {cat.name}
          </button>
        ))}
      </div>

      {/* MENU GRID */}
      <div style={styles.grid}>
        {filteredItems.map((item) => (
          <MenuItemCard key={item.id} item={item} />
        ))}
      </div>
    </div>
  );
};

const styles = {
  tabs: {
    display: "flex",
    gap: "10px",
    justifyContent: "center",
    marginBottom: "20px",
    flexWrap: "wrap",
  },
  tab: {
    padding: "8px 15px",
    border: "1px solid #ccc",
    borderRadius: "20px",
    cursor: "pointer",
    background: "white",
  },
  active: {
    padding: "8px 15px",
    border: "1px solid #ff6600",
    borderRadius: "20px",
    cursor: "pointer",
    background: "#ff6600",
    color: "white",
  },
  grid: {
    display: "grid",
    gridTemplateColumns: "repeat(auto-fill, minmax(220px, 1fr))",
    gap: "15px",
  },
};

export default MenuList;