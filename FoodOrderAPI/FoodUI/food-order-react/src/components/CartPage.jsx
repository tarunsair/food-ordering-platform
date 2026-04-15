import { useCart } from "../context/CartContext";
import { Link } from "react-router-dom";
import { useState } from "react";
import { createOrder } from "../api/api";

const CartPage = () => {
  const { cartItems, removeFromCart, getTotal, clearCart } = useCart();

  const [guestName, setGuestName] = useState("");
  const [orderSuccess, setOrderSuccess] = useState(null);

  const handlePlaceOrder = async () => {
    if (!guestName) {
      alert("Enter guest name");
      return;
    }

    if (cartItems.length === 0) {
      alert("Cart is empty");
      return;
    }

    try {
      const orderData = {
        guestName: guestName,
        tokenNumber: "", // backend will generate
        totalAmount: getTotal(),
        orderItems: cartItems.map((item) => ({
          menuItemId: item.id,
          quantity: item.quantity,
          totalPrice: item.price * item.quantity,
        })),
      };

      const response = await createOrder(orderData);

      // ✅ Save response (with token)
      setOrderSuccess(response.data);

      // ✅ clear cart
      clearCart();

    } catch (error) {
      console.error(error);
      alert("Error placing order");
    }
  };

  // 🎉 SUCCESS SCREEN
  if (orderSuccess) {
    return (
      <div style={{ padding: "20px", textAlign: "center" }}>
        <h1>✅ Order Placed Successfully!</h1>

        <h2>🎟 Token Number: {orderSuccess.tokenNumber}</h2>
        <h3>Total Paid: $ {orderSuccess.totalAmount}</h3>

        <Link to="/">⬅ Back to Menu</Link>
      </div>
    );
  }

  return (
    <div style={{ padding: "20px" }}>
      <h1>🛒 Your Cart</h1>

      <Link to="/">⬅ Back to Menu</Link>

      {cartItems.length === 0 ? (
        <p>No items in cart</p>
      ) : (
        <>
          {cartItems.map((item) => (
            <div key={item.id} style={styles.item}>
              <div>
                <h3>{item.name}</h3>
                <p>Qty: {item.quantity}</p>
                <p>$ {item.price}</p>
              </div>

              <button onClick={() => removeFromCart(item.id)}>
                Remove
              </button>
            </div>
          ))}

          <h2>Total: $ {getTotal().toFixed(2)}</h2>

          <input
            type="text"
            placeholder="Enter your name"
            value={guestName}
            onChange={(e) => setGuestName(e.target.value)}
            style={styles.input}
          />

          <button style={styles.orderBtn} onClick={handlePlaceOrder}>
            Place Order
          </button>
        </>
      )}
    </div>
  );
};

const styles = {
  item: {
    display: "flex",
    justifyContent: "space-between",
    borderBottom: "1px solid #ccc",
    padding: "10px 0",
  },
  input: {
    marginTop: "20px",
    padding: "10px",
    width: "100%",
    maxWidth: "300px",
    display: "block",
  },
  orderBtn: {
    marginTop: "10px",
    padding: "10px",
    background: "green",
    color: "white",
    border: "none",
    cursor: "pointer",
  },
};

export default CartPage;