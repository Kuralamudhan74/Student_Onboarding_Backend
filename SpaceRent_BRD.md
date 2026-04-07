# Business Requirements Document (BRD)
# SpaceRent - Peer-to-Peer Short-Term Space Rental Platform

**Document Version:** 1.0
**Date:** April 2, 2026
**Prepared By:** Product & Business Analysis Team
**Status:** Draft for Stakeholder Review

---

## Table of Contents

1. [Executive Summary](#1-executive-summary)
2. [Business Objectives](#2-business-objectives)
3. [Scope](#3-scope)
4. [Stakeholders](#4-stakeholders)
5. [User Personas](#5-user-personas)
6. [User Journey Flows](#6-user-journey-flows)
7. [Functional Requirements](#7-functional-requirements)
8. [Non-Functional Requirements](#8-non-functional-requirements)
9. [System Features & Modules](#9-system-features--modules)
10. [Data Flow Overview](#10-data-flow-overview)
11. [Assumptions & Constraints](#11-assumptions--constraints)
12. [Risks & Mitigation Strategies](#12-risks--mitigation-strategies)
13. [Revenue Model](#13-revenue-model)
14. [Future Enhancements](#14-future-enhancements)

---

## 1. Executive Summary

SpaceRent is a peer-to-peer marketplace platform (web + mobile) that enables private individuals and businesses to list their underutilized spaces for short-term rental. Renters can discover, book, and pay for spaces on an hourly or daily basis for activities such as meetings, tuition classes, workshops, small gatherings, and events.

The platform addresses a growing market gap: millions of spaces (rooms, halls, terraces, classrooms, co-working corners) sit idle for significant portions of the day. Simultaneously, freelancers, tutors, small businesses, and event organizers struggle to find affordable, flexible venues without long-term commitments.

SpaceRent connects these two sides through a commission-based marketplace model, earning a percentage on every successful booking. The MVP targets urban markets where demand density is highest.

**Comparable platforms:** Airbnb (accommodation rentals), Peerspace (event spaces), NoBroker (rental without brokers), Breather (on-demand workspaces).

**Key differentiators:**
- Hyper-local focus on short-term, activity-based space usage (not overnight stays)
- Hourly + daily pricing flexibility
- Mandatory amenity checklist for quality consistency
- Owner accept/reject/counter-offer booking flow
- Lightweight listing process designed for non-commercial space owners

---

## 2. Business Objectives

| # | Objective | Success Metric | Target (Year 1) |
|---|-----------|---------------|-----------------|
| BO-1 | Build a two-sided marketplace with strong supply | Active listings | 5,000+ verified listings in 3 metro cities |
| BO-2 | Drive demand-side adoption | Monthly active renters | 10,000+ renters completing at least 1 booking |
| BO-3 | Generate sustainable commission revenue | Gross transaction value (GTV) | INR 5 Cr GTV with 12-15% platform commission |
| BO-4 | Maintain high trust and safety | Average rating & dispute rate | Avg rating >= 4.2/5, dispute rate < 2% |
| BO-5 | Achieve product-market fit for MVP | Repeat booking rate | 30%+ renters book again within 60 days |
| BO-6 | Ensure platform reliability | Uptime SLA | 99.5% uptime |

---

## 3. Scope

### 3.1 In Scope (MVP)

| Module | Included Features |
|--------|-------------------|
| User Management | Registration, login, profile management, role-based access (Owner, Renter, Admin) |
| Space Listing | Create/edit/delete listings, image/video upload, amenity selection, pricing, availability calendar |
| Search & Discovery | Location-based search, filters (price, amenities, event type, availability), map view |
| Booking | Booking request flow, owner accept/reject/counter-offer, time slot selection, booking history |
| Payments | Secure gateway integration, hourly/daily billing, commission deduction, payout to owners |
| Notifications | In-app + push + email notifications for booking lifecycle events |
| Ratings & Reviews | Post-booking mutual ratings, public review display |
| Admin Panel | User management, listing moderation, transaction monitoring, commission configuration, dispute handling |
| Mobile App | Android & iOS apps (renter-focused), responsive web for all roles |

### 3.2 Out of Scope (MVP)

| Feature | Reason | Planned Phase |
|---------|--------|---------------|
| AI-based space recommendations | Requires usage data to train models | Phase 2 |
| Dynamic/surge pricing | Needs demand pattern analysis | Phase 2 |
| In-app chat/messaging between owner and renter | Can use notifications + phone in MVP | Phase 2 |
| Multi-language support | English-only for MVP | Phase 2 |
| Insurance/damage protection | Requires insurance partner integration | Phase 3 |
| Subscription plans for owners | Freemium model sufficient for MVP | Phase 3 |
| API for third-party integrations | Focus on core platform first | Phase 3 |
| Overnight/accommodation bookings | Out of core value proposition | Not planned |

---

## 4. Stakeholders

| Stakeholder | Role | Responsibility |
|------------|------|----------------|
| Founder / CEO | Product sponsor | Final approvals, vision alignment, investor communication |
| Product Manager | Requirements owner | Prioritization, roadmap, stakeholder alignment |
| Business Analyst | This document | Requirements gathering, user story writing, acceptance criteria |
| Engineering Lead | Technical delivery | Architecture decisions, sprint planning, technical feasibility |
| UX/UI Designer | User experience | Wireframes, prototypes, design system |
| Frontend Developers | Web + mobile build | Implement user-facing features |
| Backend Developers | API + services | Implement business logic, integrations |
| QA Lead | Quality assurance | Test planning, execution, regression |
| Marketing Lead | Go-to-market | User acquisition, onboarding campaigns, content |
| Legal/Compliance | Regulatory | Privacy policy, terms of service, local rental regulations |
| Finance | Revenue operations | Payment reconciliation, commission tracking, payouts |
| Customer Support | Post-launch | Dispute resolution, user assistance |

---

## 5. User Personas

### Persona 1: Space Owner - "Priya, the Homeowner"

| Attribute | Detail |
|-----------|--------|
| Age | 35 |
| Occupation | Homemaker with a spare hall and terrace |
| Location | Bangalore, India |
| Tech comfort | Moderate (uses WhatsApp, Instagram, Swiggy) |
| Motivation | Earn passive income from underutilized space at home |
| Pain points | Doesn't know how to find renters safely; worried about property damage; doesn't want long-term tenants |
| Goals | List her hall for tuition classes and small meetings; earn INR 15,000-25,000/month; control who uses her space |
| Key needs | Easy listing process, ability to approve/reject bookings, secure payments, calendar control |

### Persona 2: Space Owner - "Raj, the Commercial Operator"

| Attribute | Detail |
|-----------|--------|
| Age | 42 |
| Occupation | Owns a training institute with 3 classrooms |
| Location | Hyderabad, India |
| Tech comfort | High |
| Motivation | Monetize classrooms during off-hours (evenings, weekends) |
| Pain points | Classrooms sit empty 40% of the time; advertising on social media is inconsistent |
| Goals | Fill idle slots with workshop organizers and tutors; manage multiple listings efficiently |
| Key needs | Multi-listing management, hourly pricing, bulk availability settings, payout reports |

### Persona 3: Space Renter - "Ankit, the Freelance Tutor"

| Attribute | Detail |
|-----------|--------|
| Age | 28 |
| Occupation | Freelance math tutor for classes 8-12 |
| Location | Pune, India |
| Tech comfort | High (digital native) |
| Motivation | Needs a quiet space with a whiteboard to teach 3-4 students at a time |
| Pain points | Can't afford a permanent classroom; cafes are too noisy; renting a flat requires long-term commitment |
| Goals | Find affordable spaces near his students' locations; book 2-3 hours daily; keep costs under INR 300/hour |
| Key needs | Location-based search, amenity filters (whiteboard, chairs), flexible hourly booking, reliable availability |

### Persona 4: Space Renter - "Meera, the Event Organizer"

| Attribute | Detail |
|-----------|--------|
| Age | 30 |
| Occupation | Runs a small event planning company |
| Location | Mumbai, India |
| Tech comfort | High |
| Motivation | Needs unique, affordable venues for corporate workshops, birthday parties, and team-building events |
| Pain points | Hotels are expensive; community halls require weeks of advance booking; quality varies wildly |
| Goals | Find spaces that match event needs (projector, AC, parking, 30+ capacity); book for full days; compare options quickly |
| Key needs | Event-type filtering, detailed photos/videos, capacity info, full-day pricing, verified reviews |

### Persona 5: Admin - "Vikram, the Platform Admin"

| Attribute | Detail |
|-----------|--------|
| Age | 32 |
| Occupation | Operations Manager at SpaceRent |
| Tech comfort | Very high |
| Motivation | Ensure platform quality, resolve disputes, monitor growth |
| Goals | Approve/reject listings quickly; handle user complaints; track revenue; configure commission rates |
| Key needs | Dashboard with KPIs, listing moderation queue, transaction logs, user management tools |

---

## 6. User Journey Flows

### 6.1 Space Owner Journey

```
[1] REGISTER / LOGIN
     |
     v
[2] CREATE LISTING
     |-- Add title, description, space type
     |-- Upload photos/videos (min 3 photos)
     |-- Select mandatory amenities (WiFi, Tables, Chairs, Event suitability)
     |-- Select optional amenities (AC, Projector, Whiteboard, Parking, etc.)
     |-- Set pricing (hourly rate, daily rate, or both)
     |-- Define availability (recurring calendar or specific date/time slots)
     |-- Add house rules & cancellation policy
     |-- Set maximum capacity
     |-- Submit for review
     |
     v
[3] LISTING MODERATION (Admin reviews within 24-48 hrs)
     |-- Approved --> Listing goes LIVE
     |-- Rejected --> Owner notified with reason; can edit and resubmit
     |
     v
[4] RECEIVE BOOKING REQUEST (notification: push + email)
     |
     v
[5] REVIEW REQUEST
     |-- View renter profile, ratings, booking details
     |-- ACCEPT --> Booking confirmed, payment captured
     |-- REJECT --> Renter notified, no charge
     |-- COUNTER-OFFER --> Suggest alternate time/price; renter accepts or declines
     |
     v
[6] BOOKING DAY
     |-- Renter arrives, uses space
     |-- Owner ensures space is as listed
     |
     v
[7] POST-BOOKING
     |-- Rate & review renter
     |-- Receive payout (after platform commission deduction)
     |-- View earning reports in dashboard
```

### 6.2 Space Renter Journey

```
[1] REGISTER / LOGIN
     |
     v
[2] SEARCH & DISCOVER
     |-- Enter location / use GPS
     |-- Apply filters: price range, amenities, event type, date/time, capacity
     |-- Browse results (list view or map view)
     |
     v
[3] VIEW LISTING DETAIL
     |-- Photo/video gallery
     |-- Amenities, pricing, availability calendar
     |-- House rules, cancellation policy
     |-- Owner profile, ratings & reviews
     |-- Similar spaces nearby
     |
     v
[4] SELECT TIME SLOT & REQUEST BOOKING
     |-- Choose date
     |-- Select available time slots (hourly) or full day
     |-- Review pricing breakdown (base + platform fee + taxes)
     |-- Submit booking request
     |
     v
[5] WAIT FOR OWNER RESPONSE (timeout: 24 hrs, auto-cancel if no response)
     |-- ACCEPTED --> Payment captured, booking confirmed
     |-- REJECTED --> Notified, suggested alternatives shown
     |-- COUNTER-OFFER --> Review new terms, accept or decline
     |
     v
[6] BOOKING CONFIRMED
     |-- Receive confirmation with address, check-in instructions
     |-- Reminder notifications (24 hrs before, 1 hr before)
     |
     v
[7] BOOKING DAY
     |-- Navigate to space (map directions)
     |-- Use space within booked time
     |
     v
[8] POST-BOOKING
     |-- Rate & review space and owner
     |-- View booking history
     |-- Rebook or explore new spaces
```

### 6.3 Admin Journey

```
[1] LOGIN (Admin credentials, 2FA enforced)
     |
     v
[2] DASHBOARD
     |-- Overview KPIs: total users, active listings, bookings today,
     |   revenue this month, pending approvals, open disputes
     |
     v
[3] MODERATION QUEUE
     |-- Review new listing submissions
     |-- Approve / Reject with reason
     |-- Flag suspicious listings
     |
     v
[4] USER MANAGEMENT
     |-- View/search users (owners & renters)
     |-- Suspend / Ban accounts
     |-- View user activity and booking history
     |
     v
[5] TRANSACTION MONITORING
     |-- View all transactions with status
     |-- Track commission earned
     |-- Process owner payouts
     |-- Handle refund requests
     |
     v
[6] DISPUTE RESOLUTION
     |-- Review reported issues
     |-- Communicate with both parties
     |-- Issue partial/full refunds
     |-- Take action on violating accounts
     |
     v
[7] CONFIGURATION
     |-- Set/update platform commission rates
     |-- Manage space categories and amenity options
     |-- Configure notification templates
```

---

## 7. Functional Requirements

### 7.1 Module: User Management

| Req ID | Requirement | Priority | Details |
|--------|------------|----------|---------|
| UM-01 | User registration | P0 | Email + password, or Google/Apple OAuth. Phone OTP verification mandatory. |
| UM-02 | User login | P0 | Email/password + OAuth. JWT-based session management. |
| UM-03 | Role selection | P0 | User selects role during onboarding: "I want to list a space" / "I want to book a space" / Both. Role can be changed later. |
| UM-04 | Profile management | P0 | Name, phone, email, profile photo, bio, government ID upload (for owners). |
| UM-05 | KYC verification (Owners) | P1 | Government ID + address proof upload. Admin verifies before first listing goes live. |
| UM-06 | Password reset | P0 | Email-based OTP flow for password reset. |
| UM-07 | Account deactivation | P2 | User can deactivate account. Active bookings must be completed/cancelled first. |
| UM-08 | Session management | P0 | Auto-logout after 30 days inactivity. Support multiple device sessions. |

### 7.2 Module: Space Listing (Owner)

| Req ID | Requirement | Priority | Details |
|--------|------------|----------|---------|
| SL-01 | Create listing | P0 | Multi-step form: Basic info -> Amenities -> Pricing -> Availability -> Photos -> House Rules -> Submit |
| SL-02 | Space types | P0 | Predefined categories: Room, Hall, Terrace, Classroom, Conference Room, Studio, Open Space, Other |
| SL-03 | Mandatory amenities | P0 | Every listing MUST specify: WiFi (Yes/No/Speed), Tables (count), Chairs (count), Suitable events (multi-select from: Meeting, Tuition, Workshop, Gathering, Party, Photography, Yoga/Fitness, Other) |
| SL-04 | Optional amenities | P0 | Checklist: AC, Projector, Whiteboard, Parking (free/paid), Refreshments, Power Outlets, Sound System, Restroom Access, Kitchen Access, Elevator Access, Wheelchair Accessible |
| SL-05 | Image upload | P0 | Minimum 3 photos required. Maximum 15. Supported: JPG, PNG. Max 10MB per image. Auto-compress. |
| SL-06 | Video upload | P1 | Optional. Max 1 video, 60 seconds, 100MB. MP4 format. |
| SL-07 | Pricing configuration | P0 | Owner sets: Hourly rate (INR), Daily rate (INR, optional). Minimum booking duration (1 hr default). Platform displays pricing WITH commission transparently. |
| SL-08 | Availability calendar | P0 | Owner defines: Recurring weekly schedule (e.g., Mon-Fri 9AM-6PM) OR specific date/time slots. Owner can block dates. Real-time calendar sync. |
| SL-09 | House rules | P1 | Free-text field + predefined toggles: No smoking, No alcohol, No pets, No loud music, Shoes off, Max occupancy. |
| SL-10 | Cancellation policy | P1 | Owner selects: Flexible (full refund up to 24 hrs before), Moderate (full refund up to 72 hrs before), Strict (50% refund up to 7 days before). |
| SL-11 | Listing location | P0 | Address input with Google Maps pin placement. GPS coordinates stored. Approximate location shown to renters; exact address revealed after booking confirmation. |
| SL-12 | Listing moderation | P0 | New listings enter "Pending Review" state. Admin approves/rejects within 24-48 hrs. |
| SL-13 | Edit listing | P0 | Owner can edit all fields. Significant changes (price, amenities) trigger re-review. |
| SL-14 | Pause / Unpause listing | P1 | Owner can temporarily hide listing without deleting. |
| SL-15 | Delete listing | P1 | Soft delete. Cannot delete if active/upcoming bookings exist. |
| SL-16 | Maximum capacity | P0 | Owner specifies max number of people. Displayed prominently on listing. |
| SL-17 | Listing analytics | P2 | Owner dashboard: views, booking requests, acceptance rate, earnings graph. |

### 7.3 Module: Search & Discovery (Renter)

| Req ID | Requirement | Priority | Details |
|--------|------------|----------|---------|
| SD-01 | Location-based search | P0 | Search by city, area, or pin code. Auto-detect location via GPS. Radius filter (1 km - 25 km). |
| SD-02 | Map view | P1 | Google Maps integration showing listings as pins. Click pin to see quick preview. |
| SD-03 | List view | P0 | Default view. Cards with: thumbnail, title, price, rating, top amenities, distance. |
| SD-04 | Filters | P0 | Price range (slider), Space type, Event type, Amenities (multi-select), Availability (date/time picker), Capacity (min guests), Rating (min stars). |
| SD-05 | Sort options | P0 | Sort by: Relevance (default), Price low-high, Price high-low, Rating, Distance, Newest. |
| SD-06 | Search autocomplete | P1 | Location suggestions as user types. Recent searches shown. |
| SD-07 | Listing detail page | P0 | Full gallery, all amenities, pricing breakdown, availability calendar, house rules, owner profile card, reviews, "Request Booking" CTA. |
| SD-08 | Similar spaces | P2 | "You might also like" section on listing detail page based on same area + event type. |
| SD-09 | Save/Wishlist | P1 | Renter can save listings to a wishlist for later. |
| SD-10 | Recently viewed | P2 | Show last 10 viewed listings on home screen. |

### 7.4 Module: Booking

| Req ID | Requirement | Priority | Details |
|--------|------------|----------|---------|
| BK-01 | Time slot selection | P0 | Calendar date picker + available hourly slots. Greyed-out slots for unavailable times. Multi-slot selection for consecutive hours. |
| BK-02 | Booking request | P0 | Renter submits request with: selected slots, guest count, purpose of booking (optional note to owner). |
| BK-03 | Owner response | P0 | Owner receives notification. Must respond within 24 hours. Options: Accept, Reject (with reason), Counter-offer (alternate time or adjusted price). |
| BK-04 | Auto-expiry | P0 | If owner doesn't respond within 24 hours, request auto-expires. Renter notified. No charge. |
| BK-05 | Counter-offer flow | P1 | Owner proposes alternate terms. Renter gets notification to Accept or Decline counter-offer. Counter-offer expires in 12 hours. |
| BK-06 | Booking confirmation | P0 | Upon acceptance: payment captured, confirmation sent to both parties, exact address revealed to renter, calendar updated. |
| BK-07 | Booking cancellation (Renter) | P0 | Renter can cancel. Refund based on owner's cancellation policy (Flexible/Moderate/Strict). |
| BK-08 | Booking cancellation (Owner) | P0 | Owner can cancel. Full refund to renter. Penalty flag on owner's profile if > 3 cancellations in 30 days. |
| BK-09 | Booking modification | P1 | Either party can request time change. Other party must approve. Subject to availability. |
| BK-10 | Booking statuses | P0 | States: Requested -> Accepted/Rejected/Counter-offered/Expired -> Confirmed -> In Progress -> Completed -> Cancelled. |
| BK-11 | Booking history | P0 | Both owner and renter can view past and upcoming bookings with full details. |
| BK-12 | Check-in / Check-out | P2 | Optional: OTP-based check-in to mark attendance. Useful for dispute resolution. |
| BK-13 | Concurrent booking prevention | P0 | System prevents double-booking of same time slot. Real-time availability lock during payment processing. |

### 7.5 Module: Payments

| Req ID | Requirement | Priority | Details |
|--------|------------|----------|---------|
| PY-01 | Payment gateway integration | P0 | Razorpay or Stripe. Support: UPI, Credit/Debit cards, Net banking, Wallets. |
| PY-02 | Pricing breakdown | P0 | Display to renter: Base price (hours x rate), Platform service fee (% of base), GST (18% on service fee), Total payable. |
| PY-03 | Payment hold | P0 | Payment authorized (held) when renter submits request. Captured only on owner acceptance. Released if rejected/expired. |
| PY-04 | Owner payout | P0 | Payout = Base price - Platform commission. Processed within 24-48 hours after booking completion. |
| PY-05 | Payout methods | P0 | Owner registers bank account (IFSC + Account number) or UPI ID for payouts. |
| PY-06 | Refund processing | P0 | Automated refunds based on cancellation policy. Manual refunds via admin for disputes. Processed within 5-7 business days. |
| PY-07 | Invoice generation | P1 | Auto-generated invoice for each booking. Downloadable PDF for both parties. |
| PY-08 | Transaction history | P0 | Detailed log for all parties: date, amount, booking ID, status, commission. |
| PY-09 | Failed payment handling | P0 | Retry mechanism (up to 3 attempts). Notification to renter on failure. Booking not confirmed until payment succeeds. |
| PY-10 | Owner earnings dashboard | P1 | Total earnings, pending payouts, commission paid, monthly/weekly breakdown, export to CSV. |

### 7.6 Module: Notifications

| Req ID | Requirement | Priority | Trigger | Channels |
|--------|------------|----------|---------|----------|
| NT-01 | Booking request received | P0 | Renter submits booking | Owner: Push + Email + In-app |
| NT-02 | Booking accepted | P0 | Owner accepts | Renter: Push + Email + In-app |
| NT-03 | Booking rejected | P0 | Owner rejects | Renter: Push + In-app |
| NT-04 | Counter-offer sent | P1 | Owner counter-offers | Renter: Push + Email + In-app |
| NT-05 | Counter-offer response | P1 | Renter accepts/declines | Owner: Push + In-app |
| NT-06 | Booking expired | P0 | 24-hr timeout | Both: Push + In-app |
| NT-07 | Payment confirmed | P0 | Payment captured | Both: Push + Email + In-app |
| NT-08 | Payment failed | P0 | Payment fails | Renter: Push + Email |
| NT-09 | Booking reminder (24 hrs) | P0 | 24 hrs before booking | Both: Push + In-app |
| NT-10 | Booking reminder (1 hr) | P1 | 1 hr before booking | Both: Push |
| NT-11 | Booking completed | P0 | After booking end time | Both: Push + In-app ("Rate your experience") |
| NT-12 | Booking cancelled | P0 | Either party cancels | Other party: Push + Email + In-app |
| NT-13 | Payout processed | P0 | Payout sent to owner | Owner: Push + Email |
| NT-14 | Listing approved/rejected | P0 | Admin action | Owner: Push + Email + In-app |
| NT-15 | New review received | P1 | Review posted | Reviewed party: Push + In-app |
| NT-16 | Promotional/Marketing | P2 | Campaign-based | All users: Email + Push (opt-in) |

### 7.7 Module: Ratings & Reviews

| Req ID | Requirement | Priority | Details |
|--------|------------|----------|---------|
| RR-01 | Post-booking rating | P0 | Both renter and owner can rate each other (1-5 stars). Prompted after booking completion. |
| RR-02 | Review text | P0 | Optional written review (max 500 characters) accompanying the star rating. |
| RR-03 | Rating categories (Renter rates Space) | P1 | Overall, Cleanliness, Accuracy (matched description), Value for money, Amenities. |
| RR-04 | Rating categories (Owner rates Renter) | P1 | Overall, Communication, Punctuality, Respect for rules. |
| RR-05 | Review visibility | P0 | Reviews are public. Both reviews revealed simultaneously after both parties submit (or after 14-day window). |
| RR-06 | Review moderation | P1 | Admin can flag/remove reviews containing profanity, personal attacks, or spam. |
| RR-07 | Rating display | P0 | Aggregate rating (average) shown on listing card and detail page. Individual reviews listed chronologically. |
| RR-08 | Review response | P2 | Owner can post a public response to a renter's review. |

### 7.8 Module: Admin Panel

| Req ID | Requirement | Priority | Details |
|--------|------------|----------|---------|
| AP-01 | Admin dashboard | P0 | KPIs: Total users (owners/renters), Active listings, Bookings (today/week/month), Revenue, Pending approvals, Open disputes. Charts for trends. |
| AP-02 | User management | P0 | Search/filter users. View profile, activity, bookings. Suspend/ban with reason. |
| AP-03 | Listing moderation | P0 | Queue of pending listings. Preview listing detail. Approve / Reject with reason. Bulk actions. |
| AP-04 | Transaction monitoring | P0 | All transactions with filters (date, status, amount). Export to CSV. |
| AP-05 | Payout management | P0 | Pending payouts list. Approve/process payouts. Hold payouts for disputed bookings. |
| AP-06 | Dispute management | P0 | View reported issues. Timeline of booking + communications. Actions: Refund, Partial refund, Warn user, Suspend user. |
| AP-07 | Commission configuration | P0 | Set platform commission rate (%). Support: global rate, category-wise rate, promotional rate (time-bound). |
| AP-08 | Content management | P1 | Manage space categories, amenity options, event types. |
| AP-09 | Notification management | P1 | Configure notification templates. Send broadcast announcements. |
| AP-10 | Reports & analytics | P1 | Downloadable reports: Revenue, User growth, Booking trends, Top listings, Top owners, Top cities. |
| AP-11 | Admin roles & permissions | P1 | Super Admin (full access), Moderator (listings + disputes), Finance (transactions + payouts). |
| AP-12 | Audit log | P2 | Log all admin actions with timestamp and admin ID. |

---

## 8. Non-Functional Requirements

| NFR ID | Category | Requirement | Target |
|--------|----------|------------|--------|
| NFR-01 | Performance | Page load time | < 2 seconds (web), < 1.5 seconds (mobile) |
| NFR-02 | Performance | Search results response time | < 500ms for filtered queries |
| NFR-03 | Performance | API response time (95th percentile) | < 300ms |
| NFR-04 | Scalability | Concurrent users | Support 10,000 concurrent users at launch, horizontally scalable to 100,000+ |
| NFR-05 | Scalability | Database | Support 100,000+ listings and 1M+ booking records |
| NFR-06 | Availability | Uptime SLA | 99.5% uptime (planned maintenance excluded) |
| NFR-07 | Availability | Disaster recovery | RPO: 1 hour, RTO: 4 hours |
| NFR-08 | Security | Authentication | JWT with refresh tokens. OAuth 2.0 for social login. Token expiry: 15 min access, 7 day refresh. |
| NFR-09 | Security | Authorization | Role-based access control (RBAC). API-level permission checks. |
| NFR-10 | Security | Data encryption | TLS 1.2+ for transit. AES-256 for sensitive data at rest (passwords, payment info). |
| NFR-11 | Security | Password policy | Minimum 8 characters, 1 uppercase, 1 number, 1 special character. Bcrypt hashing. |
| NFR-12 | Security | Payment security | PCI DSS compliance via payment gateway. No card data stored on platform servers. |
| NFR-13 | Privacy | Data compliance | GDPR-aware design. User data deletion on request. Consent-based marketing communications. |
| NFR-14 | Privacy | Location privacy | Exact address hidden until booking confirmed. Approximate location (500m radius) shown in search. |
| NFR-15 | Reliability | Image/media storage | CDN-backed storage (AWS S3 + CloudFront or equivalent). Auto-compression. Lazy loading. |
| NFR-16 | Compatibility | Browser support | Chrome, Safari, Firefox, Edge (latest 2 versions) |
| NFR-17 | Compatibility | Mobile support | Android 9+, iOS 14+ |
| NFR-18 | Accessibility | WCAG compliance | WCAG 2.1 Level AA for web. Screen reader support. |
| NFR-19 | Monitoring | Logging & alerting | Centralized logging (ELK/CloudWatch). Alerts for: downtime, error rate spike (>1%), payment failures. |
| NFR-20 | Localization | Currency & timezone | INR currency. IST timezone. Extensible for multi-currency in future. |

---

## 9. System Features & Modules

### 9.1 High-Level Architecture

```
                        ┌──────────────────────────┐
                        │     Client Applications    │
                        │  ┌────────┐  ┌──────────┐ │
                        │  │  Web   │  │ Mobile   │ │
                        │  │ (React)│  │(Flutter/ │ │
                        │  │        │  │ RN/MAUI) │ │
                        │  └───┬────┘  └────┬─────┘ │
                        └──────┼────────────┼───────┘
                               │            │
                               v            v
                        ┌──────────────────────────┐
                        │      API Gateway          │
                        │   (Rate limiting, Auth)   │
                        └──────────┬───────────────┘
                                   │
              ┌────────────────────┼────────────────────┐
              │                    │                     │
              v                    v                     v
     ┌──────────────┐   ┌──────────────┐      ┌──────────────┐
     │    User       │   │   Listing    │      │   Booking    │
     │   Service     │   │   Service    │      │   Service    │
     └──────┬───────┘   └──────┬───────┘      └──────┬───────┘
            │                  │                      │
            │           ┌──────────────┐              │
            │           │   Search     │              │
            │           │   Service    │              │
            │           │ (Elasticsearch)             │
            │           └──────────────┘              │
            │                                         │
            v                    v                    v
     ┌──────────────┐   ┌──────────────┐      ┌──────────────┐
     │  Payment     │   │ Notification │      │   Review     │
     │  Service     │   │   Service    │      │   Service    │
     │ (Razorpay)   │   │ (FCM/SES)   │      └──────────────┘
     └──────────────┘   └──────────────┘
            │                  │
            v                  v
     ┌──────────────────────────────────┐
     │         Primary Database          │
     │       (PostgreSQL / SQL Server)   │
     ├──────────────────────────────────┤
     │    Cache Layer (Redis)            │
     ├──────────────────────────────────┤
     │    File Storage (S3 / Blob)       │
     ├──────────────────────────────────┤
     │    Search Index (Elasticsearch)   │
     └──────────────────────────────────┘
```

### 9.2 Module Breakdown

| Module | Description | Key Entities |
|--------|-------------|-------------|
| **Auth & Identity** | Registration, login, JWT management, OAuth, OTP verification, password management | User, Session, OTP, KYC Document |
| **Profile** | User profile CRUD, role management, KYC verification status | UserProfile, KYCVerification |
| **Listing** | Space creation, editing, media management, amenity mapping, pricing, availability, moderation | Listing, ListingMedia, Amenity, Availability, PricingRule |
| **Search** | Geo-spatial search, filtering, sorting, autocomplete | SearchIndex (Elasticsearch) |
| **Booking** | Request flow, owner response, status management, calendar blocking, cancellation | Booking, BookingSlot, CounterOffer |
| **Payment** | Gateway integration, payment hold/capture, refunds, owner payouts, invoicing | Transaction, Payout, Invoice, RefundRequest |
| **Notification** | Multi-channel delivery (push, email, in-app), template management, scheduling | Notification, NotificationTemplate, UserPreference |
| **Review** | Rating submission, aggregation, moderation, response | Review, Rating, ReviewReport |
| **Admin** | Dashboard, moderation, user management, configuration, disputes, reports | AdminAction, Dispute, CommissionConfig, AuditLog |
| **Analytics** | Event tracking, KPI computation, reporting | AnalyticsEvent, Report |

### 9.3 Core Database Entities (Simplified ERD)

```
Users
├── id (PK)
├── email, phone, password_hash
├── role (owner / renter / both)
├── kyc_status (pending / verified / rejected)
├── is_active, created_at
│
├── 1:N → Listings (as owner)
├── 1:N → Bookings (as renter)
├── 1:N → Reviews (as author)
└── 1:N → Notifications

Listings
├── id (PK), owner_id (FK → Users)
├── title, description, space_type, capacity
├── address, latitude, longitude
├── hourly_rate, daily_rate, min_booking_hours
├── cancellation_policy, house_rules
├── status (pending / active / paused / rejected)
├── created_at, updated_at
│
├── 1:N → ListingMedia (photos, videos)
├── N:N → Amenities (via ListingAmenities)
├── 1:N → AvailabilitySlots
├── 1:N → Bookings
└── 1:N → Reviews

Amenities
├── id (PK)
├── name, category (mandatory / optional)
├── icon

Bookings
├── id (PK)
├── listing_id (FK), renter_id (FK), owner_id (FK)
├── booking_date, start_time, end_time
├── guest_count, purpose_note
├── status (requested / accepted / rejected / counter_offered /
│           confirmed / in_progress / completed / cancelled / expired)
├── base_amount, service_fee, tax, total_amount
├── cancellation_reason, cancelled_by
├── created_at
│
├── 1:1 → Transaction
├── 0:1 → CounterOffer
└── 1:N → Reviews

Transactions
├── id (PK), booking_id (FK)
├── gateway_order_id, gateway_payment_id
├── amount, commission_amount, owner_payout_amount
├── status (authorized / captured / refunded / failed)
├── payout_status (pending / processed)
├── payout_date

Reviews
├── id (PK)
├── booking_id (FK), author_id (FK), target_id (FK)
├── overall_rating (1-5)
├── category_ratings (JSON)
├── review_text
├── is_visible, created_at
```

---

## 10. Data Flow Overview

### 10.1 Booking & Payment Data Flow

```
RENTER                    PLATFORM                   OWNER               PAYMENT GATEWAY
  │                          │                         │                       │
  │ 1. Select slots,        │                         │                       │
  │    submit request ──────>│                         │                       │
  │                          │ 2. Validate slots       │                       │
  │                          │    (check availability) │                       │
  │                          │                         │                       │
  │                          │ 3. Authorize payment ───┼──────────────────────>│
  │                          │<───────────────────────┼── 4. Payment held      │
  │                          │                         │                       │
  │                          │ 5. Send booking ────────>│                      │
  │                          │    request notification  │                      │
  │                          │                         │                       │
  │                          │<──────── 6. Owner       │                      │
  │                          │    accepts/rejects      │                       │
  │                          │                         │                       │
  │            ┌─────────────┼─────────────────────────┼───────────────────────┤
  │            │ IF ACCEPTED │                         │                       │
  │            │             │ 7. Capture payment ─────┼──────────────────────>│
  │            │             │<───────────────────────┼── 8. Payment captured  │
  │            │             │                         │                       │
  │<───────────┼── 9. Booking│confirmed notification   │                      │
  │            │             │────────── 10. Booking ──>│                      │
  │            │             │    confirmed notification│                      │
  │            └─────────────┤                         │                       │
  │            ┌─────────────┤                         │                       │
  │            │ IF REJECTED │                         │                       │
  │            │             │ 7. Release held ────────┼──────────────────────>│
  │            │             │    payment              │                       │
  │<───────────┼── 8. Rejected notification            │                      │
  │            └─────────────┤                         │                       │
  │                          │                         │                       │
  │     ... AFTER BOOKING COMPLETED ...                │                       │
  │                          │                         │                       │
  │                          │ 11. Calculate payout    │                       │
  │                          │    (base - commission)  │                       │
  │                          │ 12. Process payout ─────┼──────────────────────>│
  │                          │                         │<── 13. Payout sent    │
  │                          │────────── 14. Payout ──>│                       │
  │                          │    notification          │                      │
```

### 10.2 Listing Moderation Data Flow

```
OWNER                     PLATFORM                    ADMIN
  │                          │                          │
  │ 1. Submit listing ──────>│                          │
  │                          │ 2. Store as "pending" ──>│
  │                          │    (moderation queue)     │
  │                          │                          │
  │                          │<── 3. Review listing ────│
  │                          │    (check photos, info)  │
  │                          │                          │
  │                          │<── 4a. APPROVE ──────────│
  │<── 5a. Listing live      │    Status → "active"     │
  │    notification          │    Added to search index  │
  │                          │                          │
  │                          │<── 4b. REJECT ───────────│
  │<── 5b. Rejected with     │    Status → "rejected"   │
  │    reason notification   │                          │
```

---

## 11. Assumptions & Constraints

### 11.1 Assumptions

| # | Assumption | Impact if Wrong |
|---|-----------|-----------------|
| A-1 | Target market is urban India (Bangalore, Hyderabad, Mumbai, Pune, Delhi NCR initially) | Marketing strategy and regulatory research would need to be broadened |
| A-2 | Users have smartphones with internet connectivity | May need offline-friendly features or SMS fallbacks |
| A-3 | Owners are willing to rent spaces on an hourly basis to strangers | Need strong trust/safety features; may require on-ground onboarding |
| A-4 | Average booking value is INR 500 - 5,000 | Revenue projections change; commission model may need adjustment |
| A-5 | Razorpay supports all required payment flows (hold, capture, release, refund, payout) | May need to evaluate alternatives (Cashfree, PayU) |
| A-6 | Owner response time of 24 hours is acceptable to renters | May need "Instant Book" feature for pre-approved listings |
| A-7 | Admin team of 2-3 people can handle moderation at MVP scale (100 new listings/week) | May need automated moderation (image AI) earlier than planned |
| A-8 | Google Maps API is used for location services | Budget impact (~$7 per 1000 requests); may switch to OpenStreetMap for cost |
| A-9 | Platform launches as a commission-only model (no listing fees) | Need strong volume to achieve revenue targets |
| A-10 | Government regulations allow short-term space rental without special licenses in target cities | Legal review needed; may vary by city/state |

### 11.2 Constraints

| # | Constraint | Mitigation |
|---|-----------|------------|
| C-1 | MVP development budget: INR 25-30 Lakhs | Prioritize ruthlessly; use existing SaaS tools (Firebase, Razorpay, SendGrid) |
| C-2 | MVP timeline: 4-5 months to launch | Agile sprints; cut P2 features from initial release |
| C-3 | Engineering team size: 4-5 developers | Full-stack developers; shared component libraries |
| C-4 | No in-house payment processing (regulatory complexity) | Use established gateway; limits customization but reduces compliance burden |
| C-5 | Chicken-and-egg marketplace problem (need listings to attract renters, need renters to attract owners) | Seed supply first: on-ground onboarding of 200+ spaces before renter marketing push |
| C-6 | Payment gateway commission (2-3%) is a cost | Factor into commission calculations; negotiate volume discounts post-scale |

---

## 12. Risks & Mitigation Strategies

| Risk ID | Risk | Likelihood | Impact | Mitigation Strategy |
|---------|------|-----------|--------|---------------------|
| R-01 | Low initial supply of listings | High | Critical | Pre-launch: on-ground team onboards 200+ spaces in 2 cities. Offer 0% commission for first 3 months to early owners. |
| R-02 | Property damage or safety incidents | Medium | Critical | KYC verification for owners. Renter reviews visible. House rules enforcement. Phase 2: Optional damage deposit. Phase 3: Insurance partnership. |
| R-03 | Fraudulent listings (fake photos, non-existent spaces) | Medium | High | Admin moderation for all new listings. Photo verification guidelines. Renter reviews flag inaccurate listings. |
| R-04 | Payment disputes / chargebacks | Medium | High | Clear cancellation policies. Payment hold mechanism. Admin dispute resolution. Documented booking evidence. |
| R-05 | Platform circumvention (users transact offline after discovery) | High | High | Reveal exact address only after confirmed booking. Offer booking protection benefits (refund guarantee). Build habit through convenience. |
| R-06 | Poor search relevance / user can't find what they need | Medium | High | Invest in search quality (Elasticsearch). Collect search feedback. A/B test ranking algorithms. |
| R-07 | Regulatory changes around short-term rentals | Low | High | Legal monitoring. Flexible terms of service. City-specific compliance. |
| R-08 | Scalability issues under load | Low | Medium | Cloud-native architecture. Load testing before launch. Auto-scaling infrastructure. |
| R-09 | Low repeat booking rate | Medium | High | Post-booking engagement (recommendations, favorites). Quality enforcement via reviews. Loyalty discounts in Phase 2. |
| R-10 | Competitor entry (large player like Airbnb expanding) | Low | Medium | Focus on hyper-local, short-term niche. Build community. Speed of execution. Local market expertise. |

---

## 13. Revenue Model

### 13.1 Commission Structure

| Parameter | Value | Notes |
|-----------|-------|-------|
| Renter service fee | 10% of base booking amount | Paid by renter on top of listing price |
| Owner platform fee | 5% of base booking amount | Deducted from owner's earnings |
| **Effective platform take rate** | **~15% of booking value** | Combined revenue per transaction |
| GST on service fee | 18% (applicable per Indian tax law) | Charged to renter; remitted by platform |
| Payment gateway fee | 2-3% (absorbed by platform from commission) | Razorpay standard rates |
| **Net platform revenue per booking** | **~12-13% of booking value** | After gateway fees |

### 13.2 Revenue Calculation Example

| Line Item | Amount (INR) |
|-----------|-------------|
| Listing hourly rate | 500 |
| Booking: 4 hours | |
| **Base amount** | **2,000** |
| Renter service fee (10%) | 200 |
| GST on service fee (18%) | 36 |
| **Total renter pays** | **2,236** |
| Owner platform fee (5%) | 100 |
| **Owner receives** | **1,900** |
| **Platform gross revenue** | **300** (200 + 100) |
| Payment gateway fee (~2.5%) | ~56 |
| **Platform net revenue** | **~244** |

### 13.3 Revenue Projections (Year 1)

| Quarter | Active Listings | Monthly Bookings | Avg. Booking Value (INR) | Monthly GTV (INR) | Monthly Net Revenue (INR) |
|---------|----------------|-----------------|-------------------------|-------------------|--------------------------|
| Q1 | 500 | 200 | 1,500 | 3,00,000 | 36,000 |
| Q2 | 1,500 | 800 | 1,800 | 14,40,000 | 1,72,800 |
| Q3 | 3,000 | 2,500 | 2,000 | 50,00,000 | 6,00,000 |
| Q4 | 5,000 | 6,000 | 2,200 | 1,32,00,000 | 15,84,000 |
| **Year 1 Total** | | **~28,500** | | **~2 Cr** | **~24 Lakhs** |

### 13.4 Future Revenue Streams (Post-MVP)

| Stream | Description | Estimated Launch |
|--------|-------------|-----------------|
| Featured listings | Owners pay to boost listing visibility in search results | Phase 2 |
| Subscription plans | Monthly plans for high-volume owners (lower commission rate) | Phase 2 |
| Premium badges | "Verified" or "SuperHost" badge for trusted owners (paid) | Phase 2 |
| Ancillary services | Catering, AV equipment, cleaning (marketplace add-ons, commission on each) | Phase 3 |
| Enterprise bookings | Corporate accounts with invoicing, bulk bookings, dedicated support | Phase 3 |
| Advertising | Sponsored placements by local businesses on listing pages | Phase 3 |

---

## 14. Future Enhancements

### Phase 2 (Month 6-12)

| Feature | Description | Business Value |
|---------|-------------|---------------|
| **AI-powered recommendations** | Personalized space suggestions based on booking history, preferences, and browsing behavior | Increase discovery and repeat bookings by 20-30% |
| **Dynamic pricing** | Suggest optimal pricing to owners based on demand patterns, day of week, season, and competitor pricing | Increase owner earnings by 15%, platform revenue by 10% |
| **In-app messaging** | Real-time chat between owner and renter (pre and post booking) | Reduce booking abandonment; improve communication |
| **Instant Book** | Owners can enable auto-accept for bookings that meet their criteria | Reduce booking friction; improve conversion |
| **Calendar sync** | Sync availability with Google Calendar, Outlook | Reduce double-booking; ease owner management |
| **Multi-language support** | Hindi, Kannada, Telugu, Tamil, Marathi | Expand addressable market beyond English speakers |
| **Referral program** | Users earn credits for referring new owners and renters | Organic growth channel |
| **Advanced analytics (Owner)** | Competitive pricing insights, demand heatmaps, occupancy optimization | Owner retention and satisfaction |

### Phase 3 (Month 12-18)

| Feature | Description | Business Value |
|---------|-------------|---------------|
| **Insurance integration** | Optional damage protection insurance for bookings | Increase owner trust; premium revenue stream |
| **Recurring bookings** | Renters can book same space on a recurring schedule (weekly tuition, etc.) | Lock in repeat revenue; reduce churn |
| **Virtual tours (360)** | 360-degree photo/video tours of spaces | Increase booking confidence; reduce disputes |
| **API marketplace** | Open API for event planners, co-working aggregators, corporate tools | New distribution channels |
| **AI moderation** | Automated photo/content review for listing submissions | Reduce admin workload by 60-70% |
| **Smart lock integration** | IoT-enabled keyless entry for self-service check-in | Reduce no-shows; improve experience |
| **Multi-city expansion** | Tier-2 cities (Jaipur, Lucknow, Kochi, Chandigarh) | Grow addressable market 3x |
| **Corporate dashboard** | Companies manage employee space bookings with centralized billing | Enterprise revenue stream |

---

## Appendix A: Glossary

| Term | Definition |
|------|-----------|
| GTV | Gross Transaction Value - total value of all bookings processed |
| Take rate | Percentage of GTV retained by the platform as revenue |
| Listing | A space published on the platform by an owner |
| Booking | A confirmed reservation of a space for a specific time |
| Counter-offer | An alternate proposal (time/price) from the owner in response to a booking request |
| Payout | Transfer of earnings from the platform to the owner's bank account |
| KYC | Know Your Customer - identity verification process |
| RBAC | Role-Based Access Control |
| RPO | Recovery Point Objective - maximum acceptable data loss in a disaster |
| RTO | Recovery Time Objective - maximum acceptable downtime in a disaster |

---

## Appendix B: Approval Sign-off

| Role | Name | Signature | Date |
|------|------|-----------|------|
| Product Sponsor | | | |
| Product Manager | | | |
| Engineering Lead | | | |
| UX Lead | | | |
| Business Analyst | | | |

---

*This document is a living artifact and will be updated as requirements evolve through discovery, stakeholder feedback, and market validation.*
