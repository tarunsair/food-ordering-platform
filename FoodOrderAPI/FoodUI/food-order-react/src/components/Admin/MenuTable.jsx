import { useEffect, useState } from "react";
import API from "../../api/api";

export default function MenuTable({ refresh }) {
  const [items, setItems] = useState([]);

  useEffect(() => {
    API.get("/menuitems")
      .then(res => setItems(res.data));
  }, [refresh]);

  const deleteItem = (id) => {
    API.delete(`/menuitems/${id}`)
      .then(() => {
        alert("Deleted!");
        setItems(items.filter(x => x.id !== id));
      });
  };

  return (
    <div className="bg-white p-4 rounded shadow">
      <h2 className="font-bold mb-2">Menu Items</h2>

      <table className="w-full border">
        <thead>
          <tr className="bg-gray-200">
            <th>Name</th>
            <th>Price</th>
            <th>Category</th>
            <th>Action</th>
          </tr>
        </thead>

        <tbody>
          {items.map(item => (
            <tr key={item.id} className="text-center border-t">
              <td>{item.name}</td>
              <td>${item.price}</td>
              <td>{item.categoryName}</td>

              <td>
                <button
                  onClick={() => deleteItem(item.id)}
                  className="bg-red-500 text-white px-2 py-1 rounded"
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}