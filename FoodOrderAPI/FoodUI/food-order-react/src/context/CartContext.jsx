import { createContext, useContext, useState } from "react";

const CartContext = createContext();

export const useCart = () => useContext(CartContext);

export const CartProvider = ({ children }) => {
  const [cartItems, setCartItems] = useState([]);

  const addToCart = (item) => {
    const existing = cartItems.find((x) => x.id === item.id);

    if (existing) {
      setCartItems(
        cartItems.map((x) =>
          x.id === item.id ? { ...x, quantity: x.quantity + 1 } : x
        )
      );
    } else {
      setCartItems([...cartItems, { ...item, quantity: 1 }]);
    }
  };

  const removeFromCart = (id) => {
    setCartItems(cartItems.filter((x) => x.id !== id));
  };

  const getTotal = () => {
    return cartItems.reduce(
      (sum, item) => sum + item.price * item.quantity,
      0
    );
  };

  const clearCart = () => {
  setCartItems([]);
};

  return (
    <CartContext.Provider
      value={{ cartItems, addToCart, removeFromCart, getTotal, clearCart }}
    >
      {children}
    </CartContext.Provider>
  );
};