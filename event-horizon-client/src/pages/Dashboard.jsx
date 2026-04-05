import { useEffect, useState } from 'react';
import axios from 'axios';
import { motion } from 'framer-motion';
import EventCard from '../components/EventCard';

export default function Dashboard() {
  const [events, setEvents] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    // Standard ASP.NET Core URL usually is https://localhost:71xx or http://localhost:50xx
    // The user opened it via Visual Studio, check Swagger route. Typically 7000+ for standard local runs.
    // If the port was custom we would know, assuming 5000/7000 or general proxy. We will just attempt typical defaults or local dev setup. 
    // Ideally user sets vite proxy but we can fetch directly.
    const fetchEvents = async () => {
      try {
        // Trying HTTPS first assuming default Visual Studio Launch Settings. If fails, user might need to adjust.
        // Wait, typical is http://localhost:5147 or https://localhost:7147; let's try a relative approach if proxied, or absolute if not.
        // Since we enabled CORS we can just query local API. We'll use a placeholder URL and gracefully degrade to standard paths.
        // Actually eventhorizon.API is on the same machine.
        // I will use https://localhost:7168 as a generic but advise the user to map the port.
        
        // Fix for blank screen: safely handle network requests without crashing
        // Modify this URL to exactly match what Swagger uses (e.g. 7149, 7200 etc.)
        const apiUrl = import.meta.env.VITE_API_URL || 'https://localhost:7133/api/Events';
        
        try {
            const res = await axios.get(apiUrl);
            if (res.data && Array.isArray(res.data)) {
                setEvents(res.data);
            } else {
                throw new Error("API a returnat HTML în loc de JSON.");
            }
        } catch (fetchError) {
            throw new Error(`Conexiune eșuată la ${apiUrl}. Modifică URL-ul în Dashboard.jsx cu cel din Swagger!`);
        }
      } catch (err) {
        setError(err.message || "Eroare necunoscută.");
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchEvents();
  }, []);

  const containerVariants = {
    hidden: { opacity: 0 },
    show: {
      opacity: 1,
      transition: { staggerChildren: 0.1 }
    }
  };

  const itemVariants = {
    hidden: { opacity: 0, y: 20 },
    show: { opacity: 1, y: 0 }
  };

  if (loading) {
    return <div style={{ textAlign: 'center', marginTop: '4rem', color: 'var(--accent-color)' }}>Loading live data...</div>;
  }

  return (
    <div>
      <div style={{ marginBottom: '2rem' }}>
        <h2 style={{ fontSize: '2rem', fontWeight: '800' }}>Upcoming Experiences</h2>
        <p style={{ color: 'rgba(255,255,255,0.6)', marginTop: '0.5rem' }}>Discover unmissable Live Events hosted by premium organizers.</p>
      </div>

      {error && (
        <div style={{ padding: '1rem', background: 'rgba(239, 68, 68, 0.2)', border: '1px solid #ef4444', borderRadius: '8px', color: '#fca5a5', marginBottom: '2rem' }}>
          {error}
        </div>
      )}

      <motion.div 
        variants={containerVariants}
        initial="hidden"
        animate="show"
        style={{ 
          display: 'grid', 
          gridTemplateColumns: 'repeat(auto-fill, minmax(320px, 1fr))', 
          gap: '1.5rem' 
        }}
      >
        {events.map((evt) => (
          <motion.div key={evt.id} variants={itemVariants}>
            <EventCard event={evt} />
          </motion.div>
        ))}
        
        {/* If no events and no error, show empty state or dummy data for visual wow factor if API failed? */}
        {events.length === 0 && !error && (
            <p>No events found.</p>
        )}
      </motion.div>
    </div>
  );
}
