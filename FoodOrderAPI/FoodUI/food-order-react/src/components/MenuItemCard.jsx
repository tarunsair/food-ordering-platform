import { useCart } from "../context/CartContext";

const MenuItemCard = ({ item }) => {
  const { addToCart } = useCart();

  return (
    <div style={styles.card}>
      <img
        src={`/${item.imageUrl}`}
        alt={item.name}
        style={styles.image}
        />

      <div style={styles.content}>
        <h3>{item.name}</h3>
        <p style={styles.desc}>{item.description}</p>

        <div style={styles.row}>
          <span style={styles.price}>$ {item.price}</span>
          <span>{item.isVegetarian ? "🥦 Veg" : "🍗 Non-Veg"}</span>
        </div>

        <button style={styles.btn} onClick={() => addToCart(item)}>
          ➕ Add
        </button>
      </div>
    </div>
  );
};

const styles = {
  card: {
    background: "white",
    borderRadius: "15px",
    overflow: "hidden",
    boxShadow: "0 4px 12px rgba(0,0,0,0.1)",
    transition: "0.3s",
  },
  image: {
    width: "100%",
    height: "160px",
    objectFit: "cover",
  },
  content: {
    padding: "12px",
  },
  desc: {
    fontSize: "12px",
    color: "#777",
  },
  row: {
    display: "flex",
    justifyContent: "space-between",
    marginTop: "8px",
  },
  price: {
    fontWeight: "bold",
    color: "#ff6600",
  },
  btn: {
    marginTop: "10px",
    width: "100%",
    padding: "8px",
    background: "#ff6600",
    color: "white",
    border: "none",
    borderRadius: "8px",
    cursor: "pointer",
  },
};

export default MenuItemCard;