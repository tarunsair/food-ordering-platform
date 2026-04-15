import { Link } from "react-router-dom";
import { useCart } from "../context/CartContext";

const Header = () => {
  const { cartItems } = useCart();

  const totalItems = cartItems.reduce((sum, item) => sum + item.quantity, 0);

  return (
    <div style={styles.header}>
      <h2 style={styles.logo}>🍽 Food Stall</h2>

      <Link to="/cart" style={styles.cart}>
        🛒 Cart ({totalItems})
      </Link>
    </div>
  );
};

const styles = {
  header: {
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    padding: "15px 20px",
    background: "#ff6600",
    color: "white",
  },
  logo: {
    margin: 0,
  },
  cart: {
    color: "white",
    textDecoration: "none",
    fontWeight: "bold",
  },
};

export default Header;